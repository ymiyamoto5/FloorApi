namespace FloorApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SensorTag
    {
        public double? pressure { get; set; }

        public double? light { get; set; }

        public double? humidity { get; set; }

        public int? battery { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string id { get; set; }

        public double? temperature { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "datetime2")]
        public DateTime EventProcessedTime { get; set; }

        public int? PartitionId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EventEnqueuedTime { get; set; }

        public string ConnectionDeviceId { get; set; }
    }
}
