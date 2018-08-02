using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Entity
{
    public class Category : BaseEntity
    {
        public string Descripton { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
