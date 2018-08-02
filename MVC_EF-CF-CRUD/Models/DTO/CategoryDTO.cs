    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF_CF_CRUD.Models.DTO
{
    public class CategoryDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}