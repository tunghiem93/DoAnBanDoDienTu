using OA.Entity.Category;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Mappings
{
    public class CategoryEntitiesMappings : EntityTypeConfiguration<CategoryEntities>
    {
        public CategoryEntitiesMappings()
        {
            this.ToTable("Category");
            this.HasKey(z => z.Id);
            this.Property(z => z.Name).HasColumnType("nvarchar").HasMaxLength(250).IsRequired();
        }
    }
}
