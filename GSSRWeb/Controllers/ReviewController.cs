using System.Data.Entity;
using System;
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
using System.Diagnostics;

namespace GSSRMovies.Controllers
{
    public class ReviewController : Controller
    {
        private GSSRWebLogic dbLogic = new GSSRWebLogic();
        public ActionResult Create(int? id){
            if(id == null)
                return RedirectToAction("GetAllMovies", "Movie");
            if (User.Identity.IsAuthenticated)
            {
                if (isAdminUser())
                {
                    ViewBag.isAdmin = "true";
                }
                ViewBag.MovieId = (int)id;
                this.ViewBag.movie = dbLogic.GetMovieById((int)id);
                return View();
            }
            return RedirectToAction("GetAllMovies", "Movie");

        }

                // POST: Director/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int ?id,[Bind(Include = "ReviewId,ReviewText,ReviewRating")] Review review)
        {
            if (id == null)
                return RedirectToAction("Index", "Main");

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (isAdminUser())
            {
                ViewBag.isAdmin = "true";
            }



            ModelState.Remove("UserName");//to fix validation

            if (ModelState.IsValid)
            {
                review.MovieId = (int)id;
                review.Movie = dbLogic.GetMovieById(review.MovieId);
                review.ReviewDate = DateTime.Now;
                review.UserName = User.Identity.GetUserName();
                dbLogic.AddReview(review);
                dbLogic.SaveChanges();
                return RedirectToAction("GetReviewsByMovieId", "Review",new { id });
            }
            return View(review);
        }

        public ActionResult GetReviewsById(int? id)
        {
            if (isAdminUser())
            {
                ViewBag.isAdmin = "true";
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = dbLogic.GetReviewById((int)id);
            if (review == null)
            {
                return HttpNotFound();
            }
            this.ViewBag.movie = dbLogic.GetMovieById((int)id);
            return View(review);
        }

        public ActionResult GetReviewsByMovieId(int? id)
        {
            if (isAdminUser())
            {
                ViewBag.isAdmin = "true";
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Reviews = dbLogic.GetAllReviews().Where(e => id == e.MovieId);
            this.ViewBag.movie = dbLogic.GetMovieById((int)id);
            return View(Reviews.ToList());
        }


        public ActionResult GetFullReviewById(Review review)
        {
            review.Movie = dbLogic.GetMovieById(review.MovieId);
            return View(review);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("GetAllMovies");

            Review r = dbLogic.GetReviewById((int)id);
            dbLogic.DeleteReview(r);
            dbLogic.SaveChanges();
            return RedirectToAction("GetReviewsByMovieId/" + r.MovieId);

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