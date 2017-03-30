using SchoolMISDayLog.Helper;
using SchoolMISDayLog.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace SchoolMISDayLog.Controllers
{
    public class ComponentController : BaseController
    {
        private readonly DailyreportEntities1 _context;

        
        

        public ComponentController()
        {
            _context = new DailyreportEntities1();
        }
        // GET: Component 
        public ActionResult Index()
        {
            var data = _context.Components.ToList();
            return View(data);

        }



        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Modules = new SelectList(_context.Modules.ToList(), "ModuleId", "ModuleName");
            ViewBag.Developers = new SelectList(_context.Developers.ToList(), "DeveloperId", "DeveloperName");
            return View();

        }

        [HttpPost]
        public ActionResult Create(Component postComponent)

        {
            if (ModelState.IsValid)
            {
                using (DailyreportEntities1 d = new DailyreportEntities1())
                {
                    postComponent.CreatedByUserId = 1;
                    postComponent.CreatedByUserName = "Suraz";
                    postComponent.CreatedByUSerDate = DateTime.Now;
                    postComponent.DeveloperId = postComponent.DeveloperId;
                    postComponent.Status = "Finised";
                    postComponent.ModuleId = postComponent.ModuleId;
                    d.Entry(postComponent).State = EntityState.Added;
                    d.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = ModelState.GetModelStateErrors();                

                return View("Create", postComponent);
            }


        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Developers = new SelectList(_context.Developers.ToList(), "DeveloperId", "DeveloperName");
            ViewBag.Modules = new SelectList(_context.Modules.ToList(), "ModuleId", "ModuleName");
            var model = _context.Components.FirstOrDefault(x => x.ComponentId == id);
           
            return View("Edit", model);
        }



        [HttpPost]
        public ActionResult Edit(Component comp)
        {
            if (ModelState.IsValid)
            {
                comp.CreatedByUserId = 1;
                comp.CreatedByUserName = "Suraz";
                comp.CreatedByUSerDate = DateTime.Now;
                //  comp.DeveloperId = comp.DeveloperId;

                _context.Entry(comp).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");


            }
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            var model = _context.Components.FirstOrDefault(x => x.ComponentId == id);
            _context.Components.Remove(model);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }



    }
}


