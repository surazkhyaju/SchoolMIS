using SchoolMISDayLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolMISDayLog.Controllers
{
    public class DailyDeveloperTaskLogController : Controller
    {
        private readonly DailyreportEntities1 _context;
        public DailyDeveloperTaskLogController()
        {
            _context = new DailyreportEntities1();
        }
        // GET: DailyDeveloperTaskLog
        public ActionResult Index()
        {
            var data = _context.DailyDeveloperTaskLogs.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(DailyDeveloperTaskLog postDaily)
        {
            if (ModelState.IsValid)
            {

                _context.Entry(postDaily).State = System.Data.Entity.EntityState.Added;
                _context.DailyDeveloperTaskLogs.Add(postDaily);

            }
            return RedirectToAction("Index");
        }

    }
}