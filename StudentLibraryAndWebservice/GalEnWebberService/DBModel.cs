namespace GalEnWebberService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel1")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Raspberrypoop> Raspberrypoops { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.phone)
                .IsUnicode(false);
        }
    }
}
