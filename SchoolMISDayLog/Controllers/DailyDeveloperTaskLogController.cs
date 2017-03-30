using SchoolMISDayLog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolMISDayLog.Helper;

namespace SchoolMISDayLog.Controllers
{
    public class DailyDeveloperTaskLogController : BaseController
    {
        private readonly DailyreportEntities1 _context;
        public DailyDeveloperTaskLogController()
        {
            _context = new DailyreportEntities1();
        }
        // GET: DailyDeveloperTaskLog
        public ActionResult Index()
        {
            ViewBag.ControllerDetails = new SelectList(_context.ControllerDetails.ToList());
            ViewBag.Services = new SelectList(_context.Services.ToList());
            var data = _context.DailyDeveloperTaskLogs.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ControllerDetails = new SelectList(_context.ControllerDetails.ToList(), "ControllerId", "ControllerName");
            ViewBag.Services = new SelectList(_context.Services.ToList(), "ServiceId ", "ServiceName");
            return View();

        }
        [HttpPost]
        public ActionResult Create(DailyDeveloperTaskLog postDaily)
        {
            if (ModelState.IsValid)
            {

                using (DailyreportEntities1 d = new DailyreportEntities1())
                {
                    d.Entry(postDaily).State = EntityState.Added;
                    d.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = ModelState.GetModelStateErrors();
                ViewBag.ControllerDetails = new SelectList(_context.ControllerDetails.ToList(), "ControllerId", "ControllerName");
                ViewBag.Services = new SelectList(_context.Services.ToList(), "ServiceId ", "ServiceName");

                return View("Create", postDaily);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.ControllerDetails = new SelectList(_context.ControllerDetails.ToList(), "ControllerId", "controllerName");
            ViewBag.Services = new SelectList(_context.Services.ToList(), "ServiceId", "serviceName");
            var model = _context.DailyDeveloperTaskLogs.FirstOrDefault(x => x.DailyDeveloperTaskLogId == id);
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Edit(DailyDeveloperTaskLog postLog)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(postLog).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.DailyDeveloperTaskLogs.FirstOrDefault(x => x.DailyDeveloperTaskLogId == id);
            _context.DailyDeveloperTaskLogs.Remove(model);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }

    }

}
