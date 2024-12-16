using CodeFirstRelation.Models.Entity;
using Microsoft.EntityFrameworkCore;
namespace Relations.Context
{
    public class PatikaSecondDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAKICI53;Database=PatikaCodeFirstDb2;Trusted_Connection=True;TrustServerCertificate=True;");

            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
