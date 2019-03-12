using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElGuerre.PowerBI.PerformanceCounters.Data
{    
    public class AverageCounter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MachineName { get; set; }
        public double ProcessorTime { get; set; }
        public double AvailableMemoryGB { get; set; }
        public double AvailableDiskSpaceGB { get; set; }
    }
}
