using Microsoft.EntityFrameworkCore;

namespace EnumAsDiscriminator.API
{
    public class DataContext : DbContext
    {
        public DbSet<Left> Lefts { get; set; }

        public DbSet<Right> Rights { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Base>(builder =>
            {
                builder.HasDiscriminator<Direction>(nameof(Base.Direction))
                       .HasValue<Left>(Direction.Left)
                       .HasValue<Right>(Direction.Right);
            });

            modelBuilder.Entity<Left>(builder =>
            {
                builder.Property(l => l.Number).HasColumnName(nameof(Left.Number));
            });

            modelBuilder.Entity<Right>(builder =>
            {
                builder.Property(l => l.Number).HasColumnName(nameof(Right.Number));
            });
        }
    }
}