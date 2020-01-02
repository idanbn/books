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
    public class WriterController : Controller
    {
        private GSSRWebLogic dbLogic = new GSSRWebLogic();

        // GET: Writer
        public ActionResult GetAllWriters(string sortOrder, string queryString, string currentFilter, int? page)
        {
            if (isAdminUser())
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
            var writer = dbLogic.GetAllWriters();
            if (!String.IsNullOrEmpty(queryString))
            {
                writer = writer.Where(s => s.WriterName.Contains(queryString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    writer = writer.OrderByDescending(t => t.WriterName);
                    break;
                case "name":
                    writer = writer.OrderBy(t => t.WriterName);
                    break;
                case "birthPlace_desc":
                    writer = writer.OrderByDescending(t => t.PlaceOfBirth);
                    break;
                case "birthPlace":
                    writer = writer.OrderBy(t => t.PlaceOfBirth);
                    break;
                case "age_desc":
                    writer = writer.OrderByDescending(t => t.DateOfBirth);
                    break;
                case "age":
                    writer = writer.OrderBy(t => t.DateOfBirth);
                    break;

            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(writer.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult GetWriterByMovieId(int writerId)
        {
            var writers = dbLogic.GetAllWriters().Where(e => writerId == e.WriterId);
            return View(writers.ToList());
        }
        // GET: Actor/Details/5
        public ActionResult GetWriterById(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer writer = dbLogic.GetWriterById((int)id);
            if (writer == null)
            {
                return HttpNotFound();
            }
            return View(writer);
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
        public ActionResult Create([Bind(Include = "WriterId,WriterName,PlaceOfBirth,DateOfBirth")] Writer writer)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            if (ModelState.IsValid)
            {
                dbLogic.AddWriter(writer);
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllWriters");
            }

            return View(writer);
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
            Writer writer = dbLogic.GetWriterById((int)id);
            if (writer == null)
            {
                return HttpNotFound();
            }
            return View(writer);
        }

        // POST: Actor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WriterId,WriterName,PlaceOfBirth,DateOfBirth")] Writer writer)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            if (ModelState.IsValid)
            {

                dbLogic.UpdateWriter(writer);
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllWriters");
            }
            return View(writer);
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
            Writer writer = dbLogic.GetWriterById((int)id);
            if (writer == null)
            {
                return HttpNotFound();
            }
            return View(writer);
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
            Writer writer = dbLogic.GetWriterById(id);
            dbLogic.DeleteWriter(writer);
            dbLogic.SaveChanges();
            return RedirectToAction("GetAllWriters");
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
