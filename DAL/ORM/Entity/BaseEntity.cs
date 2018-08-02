using DAL.ORM.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Entity
{
    public class BaseEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime? AddedDate { get; set; }
        public Status Status { get; set; }
    }
}
