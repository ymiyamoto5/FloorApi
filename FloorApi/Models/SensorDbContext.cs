namespace FloorApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SensorDbContext : DbContext
    {
        public SensorDbContext()
            : base("name=SensorDbContext")
        {
        }

        public virtual DbSet<AlpsSensor> AlpsSensors { get; set; }
        public virtual DbSet<SensorTag> SensorTags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
