using OA.Entity.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Mappings
{
    public class UserEntitiesMappings : EntityTypeConfiguration<UsersEntities>
    {
        public UserEntitiesMappings()
        {
            this.ToTable("Users");
            this.HasKey(z => z.Id);
            this.Property(z => z.Name).HasColumnType("nvarchar").HasMaxLength(250).IsOptional();
            this.Property(z => z.Email).HasColumnType("nvarchar").HasMaxLength(250).IsRequired();
            this.Property(z => z.Password).HasColumnType("nvarchar").HasMaxLength(250).IsRequired();
            this.Property(z => z.PhoneNumber).HasColumnType("varchar").HasMaxLength(11).IsOptional();
            this.Property(z => z.Address).HasColumnType("nvarchar").HasMaxLength(250).IsRequired();
        }
    }
}
