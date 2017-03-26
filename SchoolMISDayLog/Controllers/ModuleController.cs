using SchoolMISDayLog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolMISDayLog.Controllers
{
    public class ModuleController : Controller
    {
        private readonly DailyreportEntities _context;

        public string ModuleController1 { get; private set; }

        public ModuleController()
        {
            _context = new DailyreportEntities();
        }
        // GET: Module
        public ActionResult Index()
        {
            var data = _context.Modules.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Module postModule)
        {
            if (ModelState.IsValid)
            {


                using (DailyreportEntities dre = new DailyreportEntities())
                {
                    postModule.CreatedByUserId = 1;
                    postModule.CreatedByUSerDate = DateTime.Now;
                    postModule.CreatedByUserName = "suraz";
                    dre.Entry(postModule).State = EntityState.Added;
                    dre.SaveChanges();
                }


            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.Modules.FirstOrDefault(x => x.ModuleId == id);
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Edit(Module model)

        {
            if (ModelState.IsValid)
            {
                using (DailyreportEntities dre = new DailyreportEntities())
                {
                    model.CreatedByUserId = 1;
                    model.CreatedByUSerDate = DateTime.Now;
                    model.CreatedByUserName = "suraz";
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
            var model = _context.Modules.FirstOrDefault(x => x.ModuleId == id);
            _context.Modules.Remove(model);
            _context.SaveChanges();
            return Json(new { Issuccess = true });

        }


    }
}