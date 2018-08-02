using DAL.ORM.Entity;
using MVC_EF_CF_CRUD.Models.DTO;
using System.Collections.Generic;


namespace MVC_EF_CF_CRUD.Models.VM
{
    public class ProductVM
    {
        public ProductVM()
        {
            Categories = new List<Category>();
            Product = new ProductDTO();

        }

        public List<Category> Categories { get; set; }
        public ProductDTO Product { get; set; }
    }
}