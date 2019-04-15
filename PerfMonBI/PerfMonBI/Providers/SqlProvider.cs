using ElGuerre.PowerBI.PerformanceCounters.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElGuerre.PowerBI.PerformanceCounters.Providers
{
    public class SqlProvider
    {
        // Readonly context avoid System.InvalidOperationException Exceptions:
        // A second operation started on this context before a previous operation completed. 
        // This is usually caused by different threads using the same instance of DbContext, 
        // however instance members are not guaranteed to be thread safe.
        private readonly DataContext _dataContext;

        public SqlProvider()
        {
            _dataContext = new DataContext();
        }

        public async Task<bool> AddData(PerfCounter counterInfo)
        {
            _dataContext.Add(counterInfo);
            return await _dataContext.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateAverageData(IList<PerfCounter> counters)
        {
            var avgCounters = counters                
                .GroupBy(c => c.MachineName)
                .Select(c => new AverageCounter()
                {
                    MachineName = c.First().MachineName,
                    ProcessorTime = c.Sum(x => x.ProcessorTime) / c.Count() ,
                    AvailableMemoryGB = c.Sum(x => x.AvailableMemoryGB) / c.Count(),
                    AvailableDiskSpaceGB = c.Sum(x => x.AvailableDiskSpaceGB) / c.Count()
                });

            await _dataContext.AverageCounters.AddRangeAsync(avgCounters);
            var affected = await _dataContext.SaveChangesAsync();
            return affected > 0;
        }
    }
}
