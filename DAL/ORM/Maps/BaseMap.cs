using DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.ORM.Maps
{
    public class BaseMap<T> : EntityTypeConfiguration<T> where T:BaseEntity
    {
        public BaseMap()
        {
            Property(x => x.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.AddedDate).HasColumnType("datetime2").IsOptional();

            Property(x => x.Status).HasColumnName("Status").IsOptional();
        }
    }
}
