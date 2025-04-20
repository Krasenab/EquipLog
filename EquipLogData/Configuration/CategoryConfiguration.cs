

using EquipLog.Data.SQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquipLogData.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.CreateCategories());
        }
        private Category[] CreateCategories() 
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category c1 = new Category
            {
                Id = 1,
                CategoryName = "Cleaning / Surface Preparation"
            };
            Category c2 = new Category
            {
                Id = 2,
                CategoryName = "Material Mixing / Vacuum Degassing"
            };
            Category c3 = new Category
            {   Id = 3,
                CategoryName = "Dosing / Dispensing Systems"
            };
            Category c4 = new Category
            {
                Id = 4,
                CategoryName = "Selective Conformal Coating"
            };
            Category c5 = new Category
            {
                Id = 5,
                CategoryName = "Spray Coating Systems"
            };

            Category c6 = new Category
            {
                Id = 6,
                CategoryName = "Material Handling"
            };
            Category c7 = new Category
            {
                Id = 7,
                CategoryName = "Potting / Encapsulation"
            };

            categories.Add(c1);
            categories.Add(c2);
            categories.Add(c3);
            categories.Add(c4);
            categories.Add(c5);
            categories.Add(c6);
            categories.Add(c7);

            return categories.ToArray();
        }
    }
}
