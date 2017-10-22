using System;
using System.Diagnostics;
using static System.Console;
using System.Linq;

namespace FeaturesCS6
{
    public static class CS6
    {
        public static bool Log(this object message, bool reThrow = false)
        {
            Trace.WriteLine(message);
            return !reThrow;
        }

        static void Main(string[] args)
        {
            try
            {

                // Some operation

                var e = new ApplicationException("Exception 11111");
                e.Data.Add(-1, "BUSINESS ERROR");
                throw e;
            }
            catch (ApplicationException ex) when (Log($"Business Error - {ex.Message}", reThrow: ex.Data.Keys.Count == 0))
            {
                // Code never reached intentionally
            }
            catch (Exception ex) when (ex.Message == "Exception 1")
            {
                Log($"Exception 1 for business !!!, {ex.Message}");
            }
            catch (Exception ex) 
            {
                Log($"ERROR GENERAL!!!, {ex.Message}");
            }


            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}
