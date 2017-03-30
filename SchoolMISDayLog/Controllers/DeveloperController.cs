using SchoolMISDayLog.Helper;
using SchoolMISDayLog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolMISDayLog.Controllers
{
    public class DeveloperController : BaseController
    {
        private readonly DailyreportEntities1 _context;
        //  public string DeveloperController { get; private set; }
        public DeveloperController()
        {
            _context = new DailyreportEntities1();
        }
        // GET: Developer
        public ActionResult Index()
        {
             var data = _context.Developers.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Developer postDeveloper)
        {
            if (ModelState.IsValid)
            {
                postDeveloper.CreatedByUserId = 1;
                postDeveloper.CreatedByUserName = "suraz";
                postDeveloper.CreatedByUSerDate = DateTime.Now;
                _context.Entry(postDeveloper).State = EntityState.Added; ;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = ModelState.GetModelStateErrors();
              

                return View("Create", postDeveloper);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.Developers.FirstOrDefault(x => x.DeveloperId == id);
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Edit(Developer model)
        {
            if (ModelState.IsValid)
            {
                using (DailyreportEntities1 dre = new DailyreportEntities1())
                {
                    model.CreatedByUserId = 1;
                    model.CreatedByUserName = "Suraz";
                    model.CreatedByUSerDate = DateTime.Now;
                    dre.Entry(model).State = EntityState.Modified;
                    dre.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var developer = _context.Developers.FirstOrDefault(x => x.DeveloperId == id);
            _context.Developers.Remove(developer);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }

    }
}