//using System;
//using System.Diagnostics;

//namespace FeaturesCS6
//{
//    public static class CS5
//    {
//        public static bool Log(this object message, bool result = false)
//        {
//            Trace.WriteLine(message);
//            return result;
//        }

//        static void Main(string[] args)
//        {
//            try
//            {
//                try
//                {

//                    // Some operation

//                    var e = new ApplicationException();
//                    e.Data.Add(-1, "BUSINESS ERROR");
//                    throw e;
//                }
//                catch (ApplicationException ex)
//                {
//                    if (ex.Data.Count > 0)
//                    {
//                        Log(String.Format("Business Error - {0}", ex.Message));
//                        throw;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Log(String.Format("ERROR GENERAL!!! - {0}", ex.Message));
//            }

//            Console.WriteLine("Pulse INTRO para finalizar...");
//            Console.ReadLine();
//        }
//    }
//}
