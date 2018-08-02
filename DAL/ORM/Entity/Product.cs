using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Entity
{
    public class Product:BaseEntity
    {
        public decimal? UnitPrice { get; set; }
        public short? Quantity { get; set; }
        public short? UnitsInStock { get; set; }
        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
