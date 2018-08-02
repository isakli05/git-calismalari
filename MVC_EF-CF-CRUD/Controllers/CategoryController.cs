using DAL.ORM.Context;
using DAL.ORM.Entity;
using DAL.ORM.Entity.Enum;
using MVC_EF_CF_CRUD.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_EF_CF_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        ProjectContext _service;

        public CategoryController()
        {
            _service = new ProjectContext();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category data)
        {
            _service.Categories.Add(data);
            _service.SaveChanges();
            return Redirect("/Category/List");
        }

        public ActionResult List()
        {
            //Aktif olan tüm ürünleri view'e gönder.
            return View(_service.Categories.Where(x => x.Status == Status.Active || x.Status == Status.Updated).ToList());
        }

        [HttpGet]
        public ActionResult Update(Guid id)
        {
            Category guncellenecek = _service.Categories.Find(id);
            CategoryDTO model = new CategoryDTO
            {
                ID = guncellenecek.ID,
                Name = guncellenecek.Name,
                Description = guncellenecek.Descripton
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Category data)
        {
            //1.Yöntem
            //Category guncellenecek = _service.Categories.Find(data.ID);
            //guncellenecek.Name = data.Name;
            //guncellenecek.Description = data.Description;
            //guncellenecek.Status=DAL.ORM.Entity.Enum.Status.Updated;
            //Direk savechanges çağırırsak çalışır ama problem çıkarabilir.
            //_service.SaveChanges();


            //2.Yöntem
            Category guncellenecek = _service.Categories.Find(data.ID);
            DbEntityEntry entry = _service.Entry(guncellenecek);
            entry.CurrentValues.SetValues(new Category
            {
                Name = data.Name,
                Descripton = data.Descripton,
                AddedDate = guncellenecek.AddedDate,
                Status = Status.Updated,
                ID = guncellenecek.ID
            });
            _service.SaveChanges();

            //DTO kullanmıyor olsaydık
            //3.Yöntem
            //DbEntityEntry entry = _service.Entry(_service.Categories.Find(data.ID));
            //entry.CurrentValues.SetValues(data);
            //_service.SaveChanges();

            return Redirect("/Category/List");
        }

        public ActionResult Delete(Guid id)
        {
            //direct silmek için
            //_service.Categories.Remove(_service.Categories.Find(id));
            //_service.SaveChanges();

            //Status değiştirme


            Category guncellencek = _service.Categories.Find(id);
            guncellencek.Status = Status.Deleted;
            _service.SaveChanges();
            return RedirectToAction("List","Category");
        }
    }
}