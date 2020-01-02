using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GSSRWeb.DAL;
using GSSRWeb.Models;
using GSSRWebMovies.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Website.Models;

namespace GSSRWeb.Controllers
{
    public class ActorLocationController : Controller
    {
        private GSSRWebLogic dbLogic = new GSSRWebLogic();

        // GET: ActorLocation/Create

        public ActionResult Create(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Main");
            if (!isAdminUser())
                return RedirectToAction("Index", "Main");
            Actor a = dbLogic.GetActorById((int)id);
            if(a==null)
                return RedirectToAction("Index", "Main");
            ViewBag.Address = a.PlaceOfBirth;
            ViewBag.ActorName = a.ActorName;
            ViewBag.ActorId = (int)id;
            return View();
        }

        // POST: ActorLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int ?id, [Bind(Include = "ActorLocationId,Lat,Long")] ActorLocation actorLocation)
        {
            if (id == null)
                return RedirectToAction("Index", "Main");

            if (!isAdminUser())
                return RedirectToAction("Index", "Main");

            if (ModelState.IsValid)
            {
                actorLocation.ActorId = (int)id;
                dbLogic.AddActorLocation(actorLocation);
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllActors","Actor");
            }
            
            return View(actorLocation);
        }

        // GET: ActorLocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Main");
            }
            if (!isAdminUser())
                return RedirectToAction("Index", "Main");

            ActorLocation actorLocation = dbLogic.GetActorLocation((int)id);

            if (actorLocation == null)
            {
                return RedirectToAction("Index", "Main");
            }
            Actor a = dbLogic.GetActorById((int)id);
            if(a==null)
                return RedirectToAction("Index", "Main");
            ViewBag.Address = a.PlaceOfBirth;
            ViewBag.ActorId = (int)id;
            ViewBag.ActorName = a.ActorName;
            return View(actorLocation);
        }

        // POST: ActorLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ?id, [Bind(Include = "ActorLocationId,Lat,Long")] ActorLocation actorLocation)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Main");
            }
            if (!isAdminUser())
                return RedirectToAction("Index", "Main");

            if (ModelState.IsValid)
            {
                actorLocation.ActorId = (int)id;
                dbLogic.UpdateActorLocation(actorLocation);
                dbLogic.SaveChanges();
                return RedirectToAction("Index", "Main");
            }
            Actor act = dbLogic.GetActorById((int)id);
            if (act == null)
            {
                return RedirectToAction("Index", "Main");
            }
            ViewBag.ActorId = (int)id;
            ViewBag.ActorName = act.ActorName;
            return View(actorLocation);
        }

        // GET: ActorLocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Main");
            }
            if (isAdminUser())
                return RedirectToAction("Index", "Main");

            ActorLocation actorLocation = dbLogic.GetActorLocation((int)id);
            if (actorLocation == null)
            {
                return HttpNotFound();
            }
            return View(actorLocation);
        }

        // POST: ActorLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActorLocation actorLocation = dbLogic.GetActorLocation(id);
            dbLogic.DeleteActorLocation(actorLocation);
            dbLogic.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            dbLogic.Dispose(disposing);
            base.Dispose(disposing);
        }
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
