using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GSSRWeb.DAL;
using GSSRWebMovies.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using Website.Models;
using Website.ViewModels;

namespace Website.Controllers
{
    public class GenreController : Controller
    {
        private GSSRWebLogic dbLogic = new GSSRWebLogic();

        // GET: Genres
        public ActionResult GetCountOfMoviesByGenre()
        {
            return View(dbLogic.GetCountOfMoviesByGenre());
        }
        public ActionResult GetAllGenres(string sortOrder, int ?page)
        {
            if (isAdminUser())
            {
                ViewBag.isAdmin = "true";
            }
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "name_desc" : sortOrder;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.IdSortParam = sortOrder == "id" ? "id_desc" : "id";
            var genres = dbLogic.GetAllGenres();
            switch (sortOrder)
            {
                case "name_desc":
                    genres = genres.OrderByDescending(t => t.GenreName);
                    break;
                case "name":
                    genres = genres.OrderBy(t => t.GenreName);
                    break;
                case "id_desc":
                    genres = genres.OrderByDescending(t => t.GenreId);
                    break;
                case "id":
                    genres = genres.OrderBy(t => t.GenreId);
                    break;

            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(genres.ToPagedList(pageNumber, pageSize));

        }


        // GET: Genres/Create
        public ActionResult Create()
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreId,GenreName")] Genre genre)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            if (ModelState.IsValid)
            {
                dbLogic.AddGenre(genre);
                dbLogic.SaveChanges();
                return RedirectToAction("GetCountOfMoviesByGenre");
            }

            return View(genre);
        }

        // GET: Genres/Edit/5
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
            Genre genre = dbLogic.GetGenreById((int)id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreId,GenreName")] Genre genre)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            if (ModelState.IsValid)
            {
                dbLogic.UpdateGenre(genre);
                dbLogic.SaveChanges();
                return RedirectToAction("GetCountOfMoviesByGenre");
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
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
            Genre genre = dbLogic.GetGenreById((int)id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            Genre genre = dbLogic.GetGenreById(id);
            dbLogic.DeleteGenre(genre);
            dbLogic.SaveChanges();
            return RedirectToAction("GetCountOfMoviesByGenre");
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
