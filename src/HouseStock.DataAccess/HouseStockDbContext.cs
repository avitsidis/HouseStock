using HouseStock.DataAccess.TypeConfigurations;
using HouseStock.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HouseStock.DataAccess
{
    public class HouseStockDbContext : DbContext
    {
        public DbSet<ProductInstance> ProductInstances { get; set; }
        public HouseStockDbContext(DbContextOptions<HouseStockDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryTypeConfiguration());

            ConfigureNameProperties(modelBuilder);
        }

        private void ConfigureNameProperties(ModelBuilder modelBuilder)
        {
            var entityTypesWithNameField = modelBuilder.Model.GetEntityTypes()
                .Where(entityType => entityType.GetDeclaredProperties().Any(property => property.Name == nameof(NamedEntity.Name)));
            foreach (var entityTypeWithNameField in entityTypesWithNameField)
            {
                var nameProperty = entityTypeWithNameField.GetDeclaredProperties().Single(property => property.Name == nameof(NamedEntity.Name));
                nameProperty.SetMaxLength(100);
                nameProperty.IsNullable = false;
            }
        }
    }
}
