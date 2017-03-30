using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolMISDayLog.Models;
using System.Data.Entity;
using SchoolMISDayLog.Helper;

namespace SchoolMISDayLog.Controllers
{


    public class ServiceController : BaseController
    {
        private readonly DailyreportEntities1 _context;
        public ServiceController()
        {
            _context = new DailyreportEntities1();

        }
        public ActionResult Index()
        {
            var data = _context.Services.ToList();
            return View(data);

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                service.CreatedByUserId = 1;
                service.CreatedByUserName = "suraz";
                service.CreatedByUSerDate = DateTime.Now;
                _context.Services.Add(service);
                _context.SaveChanges();



                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = ModelState.GetModelStateErrors();


                return View("Create", service);
            }




        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.Services.FirstOrDefault(x => x.ServiceId == id);
            return View("Edit", model);
     
        }
        [HttpPost]
        public ActionResult Edit(Service model)
        {
            if(ModelState.IsValid)
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
            var service = _context.Services.FirstOrDefault(x => x.ServiceId == id);
            _context.Services.Remove(service);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }
       
        
    }
}