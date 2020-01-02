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
    public class PictureController : Controller
    {
        private GSSRWebLogic dbLogic = new GSSRWebLogic();

        // GET: Actor
        public ActionResult GetAllPictures( int? page)
        {
            if(isAdminUser())
            {
                ViewBag.isAdmin = "true";
            }

            if (page == null)
                page = 1;


            var picture = dbLogic.GetAllPictures().OrderBy(a=>a.PictureId);
            
            
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(picture.ToPagedList(pageNumber,pageSize));
        }

        // GET: Actor/Details/5
        public ActionResult GetPictureById(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = dbLogic.GetPictureById((int)id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
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
        public ActionResult Create([Bind(Include = "PictureId,PictureName")] Picture picture)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            if (ModelState.IsValid)
            {
                dbLogic.AddPicture(picture);
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllPictures");
            }

            return View(picture);
        }

        // GET: Actor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Movie");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = dbLogic.GetPictureById((int)id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Actor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PictureId,PictureName")] Picture picture)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Main");
            }
            if (ModelState.IsValid)
            {

                dbLogic.UpdatePicture(picture);
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllPictures");
            }
            return View(picture);
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
            Picture picture = dbLogic.GetPictureById((int)id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
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
            Picture picture = dbLogic.GetPictureById(id);
            dbLogic.DeletePicture(picture);
            dbLogic.SaveChanges();
            return RedirectToAction("GetAllPictures");
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
