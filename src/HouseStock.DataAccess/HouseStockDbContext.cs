using HouseStock.DataAccess.TypeConfigurations;
using HouseStock.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HouseStock.DataAccess
{
    public class HouseStockDbContext : DbContext
    {
        public DbSet<ProductInstance> ProductInstances { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public HouseStockDbContext(DbContextOptions<HouseStockDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryTypeConfiguration());

            ConfigureNameProperties(modelBuilder);

            ConfigureShelf(modelBuilder);
        }

        private void ConfigureShelf(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Shelf>()
                .Property(s => s.Name)
                .IsRequired(true)
                .HasMaxLength(100);

            modelBuilder
                .Entity<Shelf>()
                .HasOne(p => p.Room)
                .WithMany(r => r.Shelves);

            modelBuilder
                .Entity<Shelf>()
                .HasIndex(nameof(Shelf.Room) + nameof(Room.Id), nameof(Shelf.Name))
                .IsUnique();
        }

        private void ConfigureNameProperties(ModelBuilder modelBuilder)
        {
            var entityTypesWithNameField = modelBuilder.Model.GetEntityTypes()
                .Where(entityType => typeof(NamedEntity).IsAssignableFrom(entityType.ClrType) &&
                entityType.GetDeclaredProperties().Any(property => property.Name == nameof(NamedEntity.Name)));
            foreach (var entityTypeWithNameField in entityTypesWithNameField)
            {
                var nameProperty = entityTypeWithNameField.GetDeclaredProperties().Single(property => property.Name == nameof(NamedEntity.Name));
                nameProperty.SetMaxLength(100);
                nameProperty.IsNullable = false;
                var uniqueIndex = entityTypeWithNameField.AddIndex(nameProperty);
                uniqueIndex.IsUnique = true;
            }
        }
    }
}
