﻿using SchoolMISDayLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolMISDayLog.Controllers
{
    public class LoginController : Controller
    {
        private readonly DailyreportEntities1 _context;
        public LoginController()
        {
            _context = new DailyreportEntities1();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username,string password)
        {
            var model = _context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
            if(model!=null)
            {
                Session.Add("currentUserId",model.UserId);
                return RedirectToAction("Index","Home");

            }
            else
            {
                ViewBag.message = "please enter username and password correctly ";
            }
            return View();

        }
    }
}