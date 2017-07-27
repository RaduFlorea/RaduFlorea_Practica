using RequestWorkflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RequestWorkflow.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext _db;

        public static int count = 0;

        // GET: Users
        public ActionResult Index()
        {
            _db = new ApplicationDbContext();
            
            return View(_db.Events.ToList());
        }

        public ActionResult Details(int id)
        {
            _db = new ApplicationDbContext();

            Event user = _db.Events.First(u => u.Id == id);
            return View(user);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event evnt)
        {
            _db = new ApplicationDbContext();
      
            count++;
            evnt.Id = count;
            _db.Events.Add(evnt);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            _db = new ApplicationDbContext();

            Event user = _db.Events.First(u => u.Id == id);
            return View("Create", user);
        }

        [HttpPost]
        public ActionResult Update(Event user)
        {
            _db = new ApplicationDbContext();

            Event exisingUser = _db.Events.First(u => u.Id == user.Id);
            exisingUser.FirstName = user.FirstName;
            exisingUser.LastName = user.LastName;
            exisingUser.Age = user.Age;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _db = new ApplicationDbContext();

            Event user = _db.Events.First(u => u.Id == id);
            _db.Events.Remove(user);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}