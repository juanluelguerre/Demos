using ElGuerre.PowerBI.PerformanceCounters.Data;
using System.Collections.Generic;
using System.Linq;

namespace ElGuerre.PowerBI.PerformanceCounters.Providers
{
    public class MemProvider
    {
        private List<PerfCounter> _counters;

        public MemProvider()
        {
            _counters = new List<PerfCounter>();
        }

        public IList<PerfCounter> Records => _counters;

        public bool AddDataRange(IEnumerable<PerfCounter> countersInfo)
        {
            if (countersInfo == null || countersInfo.Count() == 0)
                return false;

            _counters.AddRange(countersInfo);
            return true;
        }

        public bool AddData(PerfCounter counterInfo)
        {
            if (counterInfo == null)
                return false;

            _counters.Add(counterInfo);
            return true;
        }

        public void Clear()
        {
            _counters.Clear();
        }
    }
}
