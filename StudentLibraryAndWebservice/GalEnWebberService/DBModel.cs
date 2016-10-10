namespace GalEnWebberService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Raspberrypoop> Raspberrypoop { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.phone)
                .IsUnicode(false);
        }
    }
}
