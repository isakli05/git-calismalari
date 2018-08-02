using DAL.ORM.Context;
using DAL.ORM.Entity;
using DAL.ORM.Entity.Enum;
using MVC_EF_CF_CRUD.Models.DTO;
using MVC_EF_CF_CRUD.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_EF_CF_CRUD.Controllers
{
    public class ProductController : Controller
    {
        ProjectContext _service;
        public ProductController()
        {
            _service = new ProjectContext();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(_service.Categories.Where(x=>x.Status==Status.Active||x.Status==Status.Updated).ToList());
        }

        [HttpPost]
        public ActionResult Add(Product data)
        {
            _service.Products.Add(data);
            _service.SaveChanges();
            return RedirectToAction("List","Product");
        }

        public ActionResult List()
        {
            return View(_service.Products.Where(x=>x.Status==Status.Active|| x.Status==Status.Updated).ToList());
        }


        [HttpGet]
        public ActionResult Update(Guid id)
        {
            //Hangi ürünü güncelleyeceğimizi buluyoruz.
            Product guncellenecek = _service.Products.Find(id);
            //Vm içerisindeki productdto içerisine view içerisinde gerekli olan tüm özellikleri atıyoruz.
            ProductVM model = new ProductVM();
            model.Product.Name = guncellenecek.Name;
            model.Product.UnitPrice = (decimal)guncellenecek.UnitPrice;
            model.Product.UnitsInStock = (short)guncellenecek.UnitsInStock;
            model.Product.Quantity = (short)guncellenecek.Quantity;
            model.Product.CategoryID = guncellenecek.ID;

            //Tüm kaktegorileri güncelleme ekranına göndermek için vm içerisine ekliyoruz
            model.Categories = _service.Categories.Where(x => x.Status == Status.Active || x.Status == Status.Updated).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ProductDTO data)
        {
            Product guncellenecek = _service.Products.Find(data.ID);
            guncellenecek.Name = data.Name;
            guncellenecek.UnitPrice = data.UnitPrice;
            guncellenecek.UnitsInStock = data.UnitsInStock;
            guncellenecek.Quantity = data.Quantity;
            guncellenecek.Status = Status.Updated;
            guncellenecek.CategoryID = data.CategoryID;
            _service.SaveChanges();
            return RedirectToAction("List","Product");
        }

        public ActionResult Delete(Guid id)
        {
            Product p = _service.Products.Find(id);
            p.Status = Status.Deleted;
            _service.SaveChanges();
            return RedirectToAction("List","Product");
        }
    }
}