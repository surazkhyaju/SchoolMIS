using SchoolMISDayLog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolMISDayLog.Controllers
{
    public class UserController : Controller
    {
        private readonly DailyreportEntities1 _context;
        public UserController()
        {
            _context = new DailyreportEntities1();
        }
        // GET: User
        public ActionResult Index()
        {
            var data = _context.Users.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Developers = new SelectList(_context.Developers.ToList(), "DeveloperId", "DeveloperName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(User postUser)
        {
            if(ModelState.IsValid)
            {
                using (DailyreportEntities1 d = new DailyreportEntities1())
                {
                    d.Entry(postUser).State = EntityState.Added;
                    d.SaveChanges();
                }

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Developers=new SelectList(_context.Developers.ToList(),"DeveloperId","DeveloperName");
            var model = _context.Users.FirstOrDefault(x => x.UserId == id);
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if(ModelState.IsValid)
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id )
        {
            var model = _context.Users.FirstOrDefault(x => x.UserId == id);
            _context.Users.Remove(model);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }
    }
}