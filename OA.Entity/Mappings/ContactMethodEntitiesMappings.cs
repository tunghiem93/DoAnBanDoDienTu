using OA.Entity.ContactMethods;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Mappings
{
    public class ContactMethodEntitiesMappings : EntityTypeConfiguration<ContactMethodEntities>
    {
        public ContactMethodEntitiesMappings()
        {
            this.ToTable("ContactMethods");
            this.HasKey(z => z.Id);
            this.Property(z => z.Method).HasColumnType("nvarchar").IsRequired();
        }
    }
}
