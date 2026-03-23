using Microsoft.EntityFrameworkCore;
using SistemaDeudas.Domain.Entities;

namespace SistemaDeudas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Tab_Users");
                entity.HasKey(e => e.IdUser);

                entity.Property(a => a.Name).IsRequired().HasMaxLength(80);
                entity.Property(a => a.MiddleName).IsRequired().HasMaxLength(80);
                entity.HasIndex(a => a.Email).IsUnique(); //Investigar porque solo funciona con HasIndex y no con Property
                entity.Property(a => a.Password).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Tab_Accounts");
                entity.HasKey(e => e.IdAccount);
                entity.Property(a => a.Name).IsRequired().HasMaxLength(80);
                entity.Property(a => a.Type).IsRequired();
                entity.HasOne(a => a.User)
                      .WithMany(u => u.Accounts)
                      .HasForeignKey(a => a.IdUser)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
