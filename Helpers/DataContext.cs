using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Risco> Risco { get; set; }
        public DbSet<TipoRisco> TipoRisco { get; set; }
        public DbSet<SensoresBarragem> SensoresBarragem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Risco>(entity =>
            {
                entity.HasOne(d => d.TipoRisco)
                    .WithMany(p => p.Risco)
                    .HasForeignKey(d => d.TipoRiscoId);
            });
        }
    }
}