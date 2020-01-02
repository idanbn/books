using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GSSRWeb.DAL;
using Website.Models;
using PagedList;
using GSSRWebMovies.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using GSSRWeb.Models;

namespace Website.Controllers
{
    public class ActorController : Controller
    {
        private GSSRWebLogic dbLogic = new GSSRWebLogic();

        // GET: Actor
        public ActionResult GetAllActors(string sortOrder, string queryString, string currentFilter, string stateFilter,string currentStateFilter, int? page)
        {
            if(isAdminUser())
            {
                ViewBag.isAdmin = "true";
            }
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "name_desc" : sortOrder;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.BirthPlaceSortParam = sortOrder == "birthPlace" ? "birthPlace_desc" : "birthPlace";
            ViewBag.AgeSortParam = sortOrder == "age" ? "age_desc" : "age";

            if (queryString != null || stateFilter != null)
                page = 1;
            if(queryString == null || queryString == "")
                queryString = currentFilter==""?null:currentFilter;
            if (stateFilter == null || stateFilter =="")
                stateFilter = currentStateFilter==""?null:currentStateFilter;

            ViewBag.CurrentStateFilter = stateFilter;
            ViewBag.CurrentFilter = queryString;
            var actor = dbLogic.GetAllActors();
            if (!String.IsNullOrEmpty(queryString))
            {
                actor = actor.Where(s => s.ActorName.Contains(queryString));
            }
            if (!String.IsNullOrEmpty(stateFilter))
                actor = actor.Where(s => s.PlaceOfBirth.Contains(stateFilter));
            switch (sortOrder)
            {
                case "name_desc":
                    actor = actor.OrderByDescending(t => t.ActorName);
                    break;
                case "name":
                    actor = actor.OrderBy(t => t.ActorName);
                    break;
                case "birthPlace_desc":
                    actor = actor.OrderByDescending(t => t.PlaceOfBirth);
                    break;
                case "birthPlace":
                    actor = actor.OrderBy(t => t.PlaceOfBirth);
                    break;
                case "age_desc":
                    actor = actor.OrderByDescending(t => t.DateOfBirth);
                    break;
                case "age":
                    actor = actor.OrderBy(t => t.DateOfBirth);
                    break;

            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(actor.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult GetActorByMovieId(int actorId)
        {
            var actors = dbLogic.GetAllActors().Where(e => actorId == e.ActorId);
            return View(actors.ToList());
        }
        // GET: Actor/Details/5
        public ActionResult GetActorById(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(User.Identity.IsAuthenticated)
            {
                dbLogic.AddActorVisit((int)id, User.Identity.GetUserName());
                dbLogic.SaveChanges();
            }
            ViewBag.HasLocation = "True";
            ActorLocation al = dbLogic.GetActorLocation((int)id);
            if (al == null)
                ViewBag.HasLocation = "False";
            else
            {
                ViewBag.HasLocation = "True";
                ViewBag.Lat = al.Lat;
                ViewBag.Long = al.Long;
            }
            Actor actor = dbLogic.GetActorById((int)id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // GET: Actor/Create
        public ActionResult Create()
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            return View();
        }

        // POST: Actor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActorId,ActorName,PlaceOfBirth,DateOfBirth,ActorIMDBPage")] Actor actor)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            if (ModelState.IsValid)
            {
                dbLogic.AddActor(actor);
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllActors");
            }

            return View(actor);
        }


        // GET: Actor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActorLocation al = dbLogic.GetActorLocation((int)id);
            if (al == null)
                ViewBag.HasLocation = "False";
            else
                ViewBag.HasLocation = "True";
            Actor actor = dbLogic.GetActorById((int)id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActorId,ActorName,PlaceOfBirth,DateOfBirth,ActorIMDBPage")] Actor actor)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            if (ModelState.IsValid)
            {

                dbLogic.UpdateActor(actor);
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllActors");
            }
            return View(actor);
        }

        // GET: Actor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = dbLogic.GetActorById((int)id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            Actor actor = dbLogic.GetActorById(id);
            dbLogic.DeleteActor(actor);
            dbLogic.SaveChanges();
            return RedirectToAction("GetAllActors");
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
