using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElGuerre.PowerBI.PerformanceCounters.Data
{    
    public class PerfCounter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Property names must match Power BI Streaming Dataset value names
        public string MachineName { get; set; }
        public DateTime DateTime { get; set; }
        public double ProcessorTime { get; set; }
        public double AvailableMemoryGB { get; set; }
        public double AvailableDiskSpaceGB { get; set; }

    }
}
