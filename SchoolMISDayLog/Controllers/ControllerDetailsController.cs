using SchoolMISDayLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolMISDayLog.Controllers
{
    public class ControllerDetailsController : Controller
    {
        private readonly DailyreportEntities1 _context;
        public ControllerDetailsController()
        {
            _context = new DailyreportEntities1();
        }
        // GET: ControllerDetails
        public ActionResult Index()
        {
            var data = _context.ControllerDetails.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Components = new SelectList(_context.Components.ToList(), "ComponentId", "ComponentName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(ControllerDetail postController)

        {
            if(ModelState.IsValid)
            {
                using (DailyreportEntities1 d=new DailyreportEntities1())
                {
                    d.Entry(postController).State = System.Data.Entity.EntityState.Added;
                    d.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Components = new SelectList(_context.Components.ToList(), "ComponentId", "ComponentName");
            var model = _context.ControllerDetails.FirstOrDefault(x => x.ControllerId == id);
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Edit(ControllerDetail model)
        {
            if(ModelState.IsValid)
            {
                _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.ControllerDetails.FirstOrDefault(x => x.ControllerId == id);
            _context.ControllerDetails.Remove(model);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }
    }
}