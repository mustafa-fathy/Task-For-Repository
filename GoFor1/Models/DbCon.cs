using Microsoft.EntityFrameworkCore;

namespace GoFor1.Models
{
    public class DbCon :DbContext
    {

        public DbCon()
        {
            
        }
        public DbCon(DbContextOptions<DbCon> options) : base(options)
        {

        }
       public virtual DbSet<Courses> Courses { get; set; }
       public virtual DbSet<Students> Student { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Students>(entity =>
        //    {
        //        entity.HasKey(e => e.Id);
        //        entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        //        entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
        //        entity.Property(e => e.Course).IsRequired();
        //    });
        //}
    }
}
