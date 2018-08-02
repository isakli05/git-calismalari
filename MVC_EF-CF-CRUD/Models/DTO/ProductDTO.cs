using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF_CF_CRUD.Models.DTO
{
    public class ProductDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public short UnitsInStock { get; set; }
        public Guid CategoryID { get; set; }
    }
}