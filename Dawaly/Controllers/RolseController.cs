using Dawaly.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dawaly.Controllers
{
    [Authorize(Roles = "Admins")]
    public class RolseController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        public ActionResult Details(string id)
        {
            var Roledetails = db.Roles.Find(id);
            if(Roledetails == null) {
                return HttpNotFound();
            }

            return View(Roledetails);
        }

        // GET: Rolse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rolse/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {

                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);

        }

        // GET: Rolse/Edit/5
        public ActionResult Edit(string id)
        {
            var editRole = db.Roles.Find(id);
            if (editRole == null)
            {
                return HttpNotFound();
            }
            return View(editRole);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,Name")]IdentityRole role)
        {

            if (ModelState.IsValid) { 
            
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        public ActionResult Delete(string id)
        {
            var deleteRole = db.Roles.Find(id);
            if (deleteRole == null) {
                return HttpNotFound();
            }
            return View(deleteRole);
        }
        [HttpPost]
        public ActionResult Delete(string id, IdentityRole role)
        {
            var deleteRole = db.Roles.Find(id);
            db.Roles.Remove(deleteRole);
            db.SaveChanges();
            return RedirectToAction("Index");           
        }
    }
}
