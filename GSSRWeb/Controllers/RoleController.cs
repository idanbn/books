using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GSSRWebMovies.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using GSSRWeb.DAL;



namespace GSSR.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private ApplicationDbLogic applicationContext = new ApplicationDbLogic();

        // GET: Role
        public ActionResult GetAllRoles()
        {

            if (User.Identity.IsAuthenticated)
            {


                if (!isAdminUser())
                {
                    return RedirectToAction("GetAllMovies", "Movie");
                }
            }
            else
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }

            var Roles = applicationContext.GetAllRoles();
            return View(Roles);

        }

        public ActionResult Create()
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] IdentityRole iRole)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (ModelState.IsValid)
            {
                applicationContext.AddRole(iRole);
                applicationContext.SaveChanges();
                return RedirectToAction("GetAllMovies");
            }

            return View(iRole);
        }

        public ActionResult Delete(string id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole iRole = applicationContext.GetRoleById(id);
            if (iRole == null)
            {
                return HttpNotFound();
            }
            return View(iRole);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            IdentityRole iRole = applicationContext.GetRoleById(id);
            applicationContext.DeleteRole(iRole);
            applicationContext.SaveChanges();
            return RedirectToAction("GetAllRoles");
        }

        public ActionResult Edit(string id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole iRole = applicationContext.GetRoleById(id);
            if (iRole == null)
            {
                return HttpNotFound();
            }
            return View(iRole);
        }

        // POST: Actor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] IdentityRole iRole)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (ModelState.IsValid)
            {

                applicationContext.UpdateRole(iRole);
                applicationContext.SaveChanges();
                return RedirectToAction("GetAllRoles");
            }
            return View(iRole);
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