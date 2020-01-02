using GSSRWebMovies.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GSSRWeb.DAL;
using PagedList;
using System.Net;
using Website.ViewModels;
using System.Web.Security;
using System.Data.Entity.Validation;

namespace GSSR.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationDbLogic applicationContext = new ApplicationDbLogic();



        public ActionResult GetAllUsers(string sortOrder, string queryString, string currentFilter, int? page)
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


            sortOrder = String.IsNullOrEmpty(sortOrder) ? "name_desc" : sortOrder;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.EmailSortParam = sortOrder == "email" ? "email_desc" : "emailPlace";

            if (queryString != null)
                page = 1;
            else
                queryString = currentFilter;

            ViewBag.CurrentFilter = queryString;
            var users = applicationContext.GetAllUsers(); 
            if (!String.IsNullOrEmpty(queryString))
            {
                users= users.Where(s => s.UserName.Contains(queryString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(t => t.UserName);
                    break;
                case "name":
                    users = users.OrderBy(t => t.UserName);
                    break;
                case "email_desc":
                    users = users.OrderByDescending(t => t.Email);
                    break;
                case "email":
                    users = users.OrderBy(t => t.Email);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));


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
            IdentityUser iUser = applicationContext.GetUserById(id);
            if (iUser == null)
            {
                return HttpNotFound();
            }
            return View(iUser);
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
            ApplicationUser iUser = applicationContext.GetUserById(id);
            applicationContext.DeleteUser(iUser);
            applicationContext.SaveChanges();
            return RedirectToAction("GetAllUsers");
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
            UserRoleViewModel urvm = new UserRoleViewModel();
            ApplicationUser iUser = applicationContext.GetUserById(id);
            if (iUser == null)
            {
                return HttpNotFound();
            }
            urvm.Email = iUser.Email;
            urvm.UserName = iUser.UserName;
            urvm.Id = iUser.Id;
            urvm.RoleId =iUser.Roles.FirstOrDefault().RoleId;
            ViewBag.RoleId = new SelectList(applicationContext.GetAllRoles(), "Id", "Name", urvm.RoleId);

            return View(urvm);
        }

        // POST: Actor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Email,RoleId")] UserRoleViewModel userRole)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (ModelState.IsValid)
            {
                ApplicationUser iUser = applicationContext.GetUserById(userRole.Id);
                iUser.UserName = userRole.UserName;
                iUser.Email = userRole.Email;
                iUser.Roles.Clear();
                IdentityUserRole iUserRole = new IdentityUserRole();
                iUserRole.RoleId = userRole.RoleId;
                iUserRole.UserId = userRole.Id;
                iUser.Roles.Add(iUserRole);
                applicationContext.UpdateUser(iUser);
                applicationContext.SaveChanges();
                
               
                return RedirectToAction("GetAllUsers");
            }
            ViewBag.RoleId = new SelectList(applicationContext.GetAllRoles(), "Id", "Name", userRole.RoleId);
            return View(userRole);
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