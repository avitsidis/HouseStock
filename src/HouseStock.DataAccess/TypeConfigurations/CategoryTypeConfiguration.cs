using HouseStock.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseStock.DataAccess.TypeConfigurations
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(Category.Drinks, Category.Food, Category.Hygiene, Category.Other);
        }
    }
}
