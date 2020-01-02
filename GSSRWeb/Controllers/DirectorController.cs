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

namespace Website.Controllers
{
    public class DirectorController : Controller
    {
        private GSSRWebLogic dbLogic = new GSSRWebLogic();

        // GET: Director
        public ActionResult GetAllDirectors(string sortOrder, string queryString, string currentFilter, int? page)
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

            if (queryString != null)
                page = 1;
            else
                queryString = currentFilter;

            ViewBag.CurrentFilter = queryString;
            var Director = dbLogic.GetAllDirectors();
            if (!String.IsNullOrEmpty(queryString))
            {
                Director = Director.Where(s => s.DirectorName.Contains(queryString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    Director = Director.OrderByDescending(t => t.DirectorName);
                    break;
                case "name":
                    Director = Director.OrderBy(t => t.DirectorName);
                    break;
                case "birthPlace_desc":
                    Director = Director.OrderByDescending(t => t.PlaceOfBirth);
                    break;
                case "birthPlace":
                    Director = Director.OrderBy(t => t.PlaceOfBirth);
                    break;
                case "age_desc":
                    Director = Director.OrderByDescending(t => t.DateOfBirth);
                    break;
                case "age":
                    Director = Director.OrderBy(t => t.DateOfBirth);
                    break;

            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Director.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult GetDirectorByMovieId(int DirectorId)
        {
            var Directors = dbLogic.GetAllDirectors().Where(e => DirectorId == e.DirectorId);
            return View(Directors.ToList());
        }
        // GET: Director/Details/5
        public ActionResult GetDirectorById(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("GetAllMovies");
            }
            Director Director = dbLogic.GetDirectorById((int)id);
            if (Director == null)
            {
                return HttpNotFound();
            }
            return View(Director);
        }

        // GET: Director/Create
        public ActionResult Create()
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            return View();
        }

        // POST: Director/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DirectorId,DirectorName,PlaceOfBirth,DateOfBirth")] Director Director)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (ModelState.IsValid)
            {
                dbLogic.AddDirector(Director); 
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllDirectors");
            }

            return View(Director);
        }

        // GET: Director/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director Director = dbLogic.GetDirectorById((int)id);
            if (Director == null)
            {
                return HttpNotFound();
            }
            return View(Director);
        }

        // POST: Director/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DirectorId,DirectorName,PlaceOfBirth,DateOfBirth")] Director Director)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (ModelState.IsValid)
            {

                dbLogic.UpdateDirector(Director); 
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllDirectors");
            }
            return View(Director);
        }

        // GET: Director/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director Director = dbLogic.GetDirectorById((int)id);
            if (Director == null)
            {
                return HttpNotFound();
            }
            return View(Director);
        }

        // POST: Director/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            Director Director = dbLogic.GetDirectorById(id);
            dbLogic.DeleteDirector(Director); 
            dbLogic.SaveChanges();
            return RedirectToAction("GetAllDirectors");
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
