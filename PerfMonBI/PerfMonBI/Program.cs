//
// https://chris.koester.io/index.php/2017/12/27/push-performance-counter-data-into-a-power-bi-streaming-dataset/
//
/* 
* Retreives Performance Counter data and pushes it to a Power BI streaming dataset.
*    
* Supply your own value for the Power BI push URL in the Main method.
* Script run time (In minutes) and the push interval (In seconds) are supplied as command line arguments.
* 
* The properties of the PerfCounterPowerBI class must match the Power BI Streaming Dataset value names
* in both the class and where the object is initialized at the beginning of the while loop in the
* PushToPowerBI method.
*/
using ElGuerre.PowerBI.PerformanceCounters.Data;
using ElGuerre.PowerBI.PerformanceCounters.Providers;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace ElGuerre.PowerBI.PerformanceCounters
{
    public class PerformanceCounterConsole
    {
        #region Interop

        const int LOGON32_PROVIDER_DEFAULT = 0;
        //This parameter causes LogonUser to create a primary token. 
        const int LOGON32_LOGON_INTERACTIVE = 2;

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(
            string lpszUsername,
            string lpszDomain,
            string lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            out SafeAccessTokenHandle phToken);

        #endregion

        private const string DOMAIN = "USERSAD";
        private const string USER = "#SET THE USER#";
        private const string PWD = "SET THE USER PASSWROD";

        private const string DEV_MACHINE = "## DEV ENVIRONMENT MACHINE NAME ###";
        private const string INT_MACHINE = "## INTEGRATION ENVIRONMENT MACHINE NAME ###";

        // Get the push URL by clicking on the "API Info" button for your streaming dataset
        private const string POWER_BI_POST_URL =
            "###SET POWER BI URL ###";

        // LOCAL        
        private static readonly PerformanceCounter _cpuCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        private static readonly PerformanceCounter _memCounter = new PerformanceCounter("Memory", "Available MBytes", "");
        private static readonly PerformanceCounter _diskCounter = new PerformanceCounter("LogicalDisk", "Free Megabytes", "_Total");

        ////   SCLD01DFNFB01.usersad.everis.int
        private static PerformanceCounter _cpuCounterDev;
        private static PerformanceCounter _memCounterDev;
        private static PerformanceCounter _diskCounterDev;

        ////  SCLD01IFNFB01.usersad.everis.int
        private static PerformanceCounter _cpuCounterInt;
        private static PerformanceCounter _memCounterInt;
        private static PerformanceCounter _diskCounterInt;

        private static int pbiPauseInterval;
        private static readonly RestProvider _restProvider = new RestProvider();
        private static readonly SqlProvider _sqlProvider = new SqlProvider();
        private static readonly MemProvider _memProvider = new MemProvider();

        static async Task<int> Main(string[] args)
        {
            if (HandleArguments(args) == 1)
            {
                pbiPauseInterval = 2;
            }

            bool remote = true;

            if (remote)
            {
                // Call LogonUser to obtain a handle to an access token. 
                SafeAccessTokenHandle safeAccessTokenHandle;
                bool returnValue = LogonUser(
                    USER,
                    DOMAIN,
                    PWD,
                    LOGON32_LOGON_INTERACTIVE,
                    LOGON32_PROVIDER_DEFAULT,
                    out safeAccessTokenHandle);

                await WindowsIdentity.RunImpersonated(safeAccessTokenHandle, async () =>
                {
                    Console.WriteLine("Impersonated: " + WindowsIdentity.GetCurrent().Name);

                    try
                    {
                        _cpuCounterDev = new PerformanceCounter("Processor Information", "% Processor Time", "_Total", DEV_MACHINE);
                        _memCounterDev = new PerformanceCounter("Memory", "Available MBytes", "", DEV_MACHINE);
                        _diskCounterDev = new PerformanceCounter("LogicalDisk", "Free Megabytes", "_Total", DEV_MACHINE);

                        //_cpuCounterInt = new PerformanceCounter("Processor Information", "% Processor Time", "_Total", INT_MACHINE);
                        //_memCounterInt = new PerformanceCounter("Memory", "Available MBytes", "", INT_MACHINE);
                        //_diskCounterInt = new PerformanceCounter("LogicalDisk", "Free Megabytes", "_Total", INT_MACHINE);

                        await PushToPowerBI(POWER_BI_POST_URL, pbiPauseInterval, 1, 1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: '{ex.Message}'");
                    }
                });

            }


            return 0;
        }

        private static async Task PushToPowerBI(string url, int pbiInterval, int dataIntervalSec = 10, int averageIntervalMin = 10)
        {
            var timer = new Timer(
                (x) => _memProvider.AddDataRange(GetPerformanceData()),
                null,
                TimeSpan.FromSeconds(dataIntervalSec),
                TimeSpan.FromSeconds(dataIntervalSec));

            var timerAverage = new Timer(
                async (x) =>
                {
                    await _sqlProvider.UpdateAverageData(_memProvider.Records);
                    _memProvider.Clear();
                },
                null,
                TimeSpan.FromMinutes(averageIntervalMin),
                TimeSpan.FromMinutes(averageIntervalMin));

            while (true)
            {
                var perfCounters = GetPerformanceData();

                foreach (var c in perfCounters)
                {
                    var jsonString = JsonConvert.SerializeObject(c);

                    var response = await _restProvider.PostAsync(url, jsonString);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK
                        || response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        Console.WriteLine(jsonString);
                    }
                    else
                    {
                        Console.WriteLine($"Error trying to publish to Power BI. {response.Content}.");
                    }
                }

                Thread.Sleep(pbiInterval * 1000);
            }
        }

        private static List<PerfCounter> GetPerformanceData()
        {
            return new List<PerfCounter>()
            {
                new PerfCounter
                {
                    MachineName = DEV_MACHINE,
                    DateTime = DateTime.UtcNow,
                    ProcessorTime = _cpuCounterDev.NextValue(),
                    AvailableMemoryGB = (_memCounterDev.NextValue() / 1024),
                    AvailableDiskSpaceGB = (_diskCounterDev.NextValue() / 1024)
                }
                // ,
                //new PerfCounter
                //  {
                //      MachineName = INT_MACHINE,
                //      DateTime = DateTime.UtcNow,
                //      ProcessorTime = _cpuCounterDev.NextValue(),
                //      AvailableMemoryGB = (_memCounterDev.NextValue() / 1024),
                //      AvailableDiskSpaceGB = (_diskCounterDev.NextValue() / 1024)
                //  }
             };
        }

        private static int HandleArguments(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine($"Default value ({pbiPauseInterval}) will be appliend for interval (in seconds).");
                Console.WriteLine("Usage: PerMonBI 2");
                // Console.WriteLine("Press any key to continue.");
                //Console.ReadKey();
                return 1;
            }

            if (!int.TryParse(args[0], out pbiPauseInterval))
            {
                Console.WriteLine("No valid argument. Number expected.");
                Console.WriteLine("Usage: PerMonBI 2");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return 1;
            }

            return 0;
        }
    }
}
