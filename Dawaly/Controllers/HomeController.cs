using Dawaly.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Dawaly.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult Details(int PlaceId) 
        {

            var detailsPlace = db.Places.Find(PlaceId);
            if (detailsPlace == null) {
                HttpNotFound();
            }
            Session["PlaceId"] = PlaceId;
            return View(detailsPlace);
        
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Admins,user")]
        public ActionResult Booking() {
           
            return View();
        }
        [HttpPost]
        public ActionResult Booking(string Message) {

            try {
                var userId = User.Identity.GetUserId();
                var placeId = (int)Session["PlaceId"];

                var check = db.ApplyToPlaces.Where(a => a.PlaceId == placeId && a.UserId == userId).ToList();
                if (check.Count < 1)
                {
                    var applytoplace = new ApplyToPlace();
                    applytoplace.UserId = userId;
                    applytoplace.PlaceId = placeId;
                    applytoplace.Message = Message;
                    applytoplace.ApplyDate = DateTime.Now;
                    db.ApplyToPlaces.Add(applytoplace);
                    db.SaveChanges();
                    ViewBag.Result = "Booking Done";

                }
                else
                {
                    ViewBag.Result = "Sorry , you have booked this place ";
                }
            }
            catch(Exception e){
              e =  ViewBag.Result = "Enter Your Message";    
             
            }            
            return View();

        }

        [Authorize]
        public ActionResult GetPlacesByPublisher()
        {

            var UserId = User.Identity.GetUserId();
            var PlaceByPublisher = from app in db.ApplyToPlaces
                                   join place in db.Places
                                   on app.PlaceId equals place.Id
                                   where  place.User.Id==UserId
                                   select app;
            return View(PlaceByPublisher.ToList());
        }        
        [Authorize]
        public ActionResult GetPlacesbyUser() {

            var UserId = User.Identity.GetUserId();
            var Places = db.ApplyToPlaces.Where(a => a.UserId == UserId);
            return View(Places.ToList());

        }
        [Authorize]
        public ActionResult DetailsPlaceByUser(int id) {
            var detailsPlace = db.ApplyToPlaces.Find(id);
            if (detailsPlace == null)
            {
                HttpNotFound();
            }
            return View(detailsPlace);
        }

        [Authorize]
        public ActionResult EditApply(int id)
        {
            var edit = db.ApplyToPlaces.Find(id);
            if (edit==null)
            {
                return HttpNotFound();
            }
            return View(edit);
        }
 
        [HttpPost]
        public ActionResult EditApply(ApplyToPlace apply)
        { 
            if (ModelState.IsValid) {

                apply.ApplyDate = DateTime.Now;

                db.Entry(apply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetPlacesbyUser");
            }
            return View(apply);
        }

        public ActionResult Deleteapply(int id)
        {
            var deleteapply = db.ApplyToPlaces.Find(id);
            if (deleteapply == null)
            {
                return HttpNotFound();
            }
            return View(deleteapply);
        }
        [HttpPost]
        public ActionResult Deleteapply(ApplyToPlace place)
        {
            var deleteapply = db.ApplyToPlaces.Find(place.Id);
            db.ApplyToPlaces.Remove(deleteapply);
            db.SaveChanges();
            return RedirectToAction("GetPlacesbyUser");
        }
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContentModel contentModel)
        {

            try {
                var mail = new MailMessage();
                var loginfo = new NetworkCredential("Email", "Password");
                mail.From = new MailAddress(contentModel.Email);
                mail.To.Add(new MailAddress("Email"));
                mail.Body = contentModel.Message;

                var smtpClint = new SmtpClient("smtp.gmail.com", 587);
                smtpClint.EnableSsl = true;
                smtpClint.Credentials = loginfo;
                smtpClint.Send(mail);

                ViewBag.Message = "Done";
            }
            catch (Exception e)
            {
                ViewBag.Message = e;

            }
            
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string searchName)
        {
            var search = db.Places.Where(a => a.Name.Contains(searchName)
            || a.Location.Contains(searchName)
            || a.Category.CategortName.Contains(searchName)
            || a.Details.Contains(searchName)
             ).ToList();
            return View(search);
        }
    }
}