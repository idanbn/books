using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GSSRWeb.DAL;
using Website.ViewModels;
using PagedList;
using GSSRWebMovies.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Website.Models
{
    public class MovieController : Controller
    {
        private GSSRWebLogic dbLogic = new GSSRWebLogic();


        // GET: Movie
        public ActionResult GetAllMovies(string sortOrder, string queryString, string currentFilter, int? page, bool descending = false ,int genreId = 0)
        {
            if (isAdminUser())
            {
                ViewBag.isAdmin = "true";
            }
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "name" : sortOrder;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Descending = descending;

            if (queryString != null)
                page = 1;
            else
                queryString = currentFilter;

            ViewBag.CurrentFilter = queryString;

            var movie = dbLogic.GetAllMovies();
            if (genreId != 0)
                movie = movie.Where(m => m.GenreId == genreId);

            if (!String.IsNullOrEmpty(queryString))
            {
                movie = movie.Where(s => s.MovieName.Contains(queryString));
            }
            switch (sortOrder)
            {
                case "name":
                    if((bool)descending)
                        movie = movie.OrderByDescending(t => t.MovieName);
                    else
                        movie = movie.OrderBy(t => t.MovieName);
                    break;
                case "year":
                    if((bool)descending)
                        movie = movie.OrderByDescending(t => t.YearOfPublish);
                    else
                        movie = movie.OrderBy(t => t.YearOfPublish);
                    break;
                case "duration":
                    if((bool)descending)
                        movie = movie.OrderByDescending(t => t.MovieDuration);
                    else
                        movie = movie.OrderBy(t => t.MovieDuration);
                    break;
                case "genre":
                    if((bool)descending)
                        movie = movie.OrderByDescending(t => t.Genre.GenreName);
                    else
                        movie = movie.OrderBy(t => t.Genre.GenreName);
                    break;
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(movie.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Slideshow()
        {
            var movie = dbLogic.GetAllMovies();
            movie = movie.Take(3);
            return View(movie.ToList());
        }
        // GET: Movie/Details/5
        public ActionResult GetMovieById(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (User.Identity.IsAuthenticated)
            {
                dbLogic.AddMovieVisit((int)id, User.Identity.GetUserName());
                dbLogic.SaveChanges();
            }
            var movie = dbLogic.GetMovieById((int)id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            string url = "http://www.omdbapi.com/?i=tt3896198&apikey=29e7cb62&t=" + movie.MovieName;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var response = (HttpWebResponse)request.GetResponse();
            string response_string = new StreamReader(response.GetResponseStream()).ReadToEnd();
            dynamic d = JObject.Parse(response_string);
            double rating = 0;
            if (d.Response.Value == "True" && d.imdbRating.Value != "N/A")
               rating = Double.Parse(d.imdbRating.Value);
            ViewBag.ImdbRating = rating;

            movie.Review = movie.Review.OrderByDescending(a => a.ReviewDate).Take(3).ToList();

            return View(movie);
        }


        // GET: Movie/Create
        public ActionResult Create()
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            ViewBag.GenreId = new SelectList(dbLogic.GetAllGenres(), "GenreId", "GenreName");
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,MovieName,YearOfPublish,GenreId,MovieDuration,PictureId,YoutubeId,Summary")] Movie movie)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (ModelState.IsValid)
            {
                dbLogic.AddMovie(movie);
                dbLogic.SaveChanges();
                return RedirectToAction("GetAllMovies");
            }

            ViewBag.GenreId = new SelectList(dbLogic.GetAllGenres(), "GenreId", "GenreName", movie.GenreId);
            return View(movie);
        }

        // GET: Movie/Edit/5
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
            Movie movie = dbLogic.GetMovieById((int)id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(dbLogic.GetAllGenres(), "GenreId", "GenreName", movie.GenreId);
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,MovieName,YearOfPublish,GenreId,MovieDuration,PictureId,YoutubeId,Summary")] Movie movie)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (ModelState.IsValid)
            {
                dbLogic.UpdateMovie(movie);
                dbLogic.SaveChanges();
                return RedirectToAction("GetMovieById/" + movie.MovieId);
            }
            ViewBag.GenreId = new SelectList(dbLogic.GetAllGenres(), "GenreId", "GenreName", movie.GenreId);
            return View(movie);
        }

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
            Movie movie = dbLogic.GetMovieById((int)id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            Movie movie = dbLogic.GetMovieById(id);
            dbLogic.DeleteMovie(movie);
            dbLogic.SaveChanges();
            return RedirectToAction("GetAllMovies");
        }
        #region Actors/Directors/Writers
        #region Add
        #region AddActor
        public ActionResult AddActorToMovie(int? MovieId, int? ActorId)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (MovieId == null || ActorId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie m = dbLogic.GetMovieById((int)MovieId);
            Actor a = dbLogic.GetActorById((int)ActorId);
            ViewBag.movieName = m.MovieName;
            ViewBag.movieId = MovieId;
            ViewBag.actorName = a.ActorName;
            ViewBag.actorId = ActorId;
            return View();

        }
        [HttpPost, ActionName("AddActorToMovie")]
        public ActionResult ConfirmAddActorToMovie(int MovieId, int ActorId)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            dbLogic.GetActorById(ActorId).Movie.Add(dbLogic.GetMovieById(MovieId));
            dbLogic.SaveChanges();
            return RedirectToAction("GetAllMovies", "Movie");

        }

        public ActionResult AddActorsToMovie(int ?id, string sortOrder, string queryString, string currentFilter, int? page)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie m = dbLogic.GetMovieById((int)id);
            ViewBag.movieId = id;
            ViewBag.movieName = m.MovieName;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "name_desc" : sortOrder;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.BirthPlaceSortParam = sortOrder == "birthPlace" ? "birthPlace_desc" : "birthPlace";
            if (queryString != null)
                page = 1;
            else
                queryString = currentFilter;

            ViewBag.CurrentFilter = queryString;
            var actor = dbLogic.GetAllActors();
            if (!String.IsNullOrEmpty(queryString))
            {
                actor = actor.Where(s => s.ActorName.Contains(queryString));
            }
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
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(actor.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region AddDirector

        public ActionResult AddDirectorToMovie(int? MovieId, int? DirectorId)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (DirectorId == null || MovieId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie m = dbLogic.GetMovieById((int)MovieId);
            Director a = dbLogic.GetDirectorById((int)DirectorId);
            ViewBag.movieName = m.MovieName;
            ViewBag.movieId = MovieId;
            ViewBag.actorName = a.DirectorName;
            ViewBag.actorId = DirectorId;
            return View();

        }
        [HttpPost, ActionName("AddDirectorToMovie")]
        public ActionResult ConfirmAddDirectorToMovie(int MovieId, int DirectorId)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            dbLogic.GetDirectorById(DirectorId).Movie.Add(dbLogic.GetMovieById(MovieId));
            dbLogic.SaveChanges();
            return RedirectToAction("GetAllMovies", "Movie");

        }

        public ActionResult AddDirectorsToMovie(int? id, string sortOrder, string queryString, string currentFilter, int? page)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie m = dbLogic.GetMovieById((int)id);
            ViewBag.movieId = id;
            ViewBag.movieName = m.MovieName;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "name_desc" : sortOrder;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.BirthPlaceSortParam = sortOrder == "birthPlace" ? "birthPlace_desc" : "birthPlace";
            if (queryString != null)
                page = 1;
            else
                queryString = currentFilter;

            ViewBag.CurrentFilter = queryString;
            var directors = dbLogic.GetAllDirectors();
            if (!String.IsNullOrEmpty(queryString))
            {
                directors = directors.Where(s => s.DirectorName.Contains(queryString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    directors = directors.OrderByDescending(t => t.DirectorName);
                    break;
                case "name":
                    directors = directors.OrderBy(t => t.DirectorName);
                    break;
                case "birthPlace_desc":
                    directors = directors.OrderByDescending(t => t.PlaceOfBirth);
                    break;
                case "birthPlace":
                    directors = directors.OrderBy(t => t.PlaceOfBirth);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(directors.ToPagedList(pageNumber, pageSize));
        }

        #endregion

        #region AddWriter
        public ActionResult AddWriterToMovie(int? MovieId, int? WriterId)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (WriterId == null || MovieId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie m = dbLogic.GetMovieById((int)MovieId);
            Writer a = dbLogic.GetWriterById((int)WriterId);
            ViewBag.movieName = m.MovieName;
            ViewBag.movieId = MovieId;
            ViewBag.actorName = a.WriterName;
            ViewBag.Id = WriterId;
            return View();

        }
        [HttpPost, ActionName("AddWriterToMovie")]
        public ActionResult ConfirmAddWriterToMovie(int MovieId, int WriterId)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            dbLogic.GetWriterById(WriterId).Movie.Add(dbLogic.GetMovieById(MovieId));
            dbLogic.SaveChanges();
            return RedirectToAction("GetAllMovies", "Movie");

        }

        public ActionResult AddWritersToMovie(int ?id, string sortOrder, string queryString, string currentFilter, int? page)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie m = dbLogic.GetMovieById((int)id);
            ViewBag.movieId = id;
            ViewBag.movieName = m.MovieName;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "name_desc" : sortOrder;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.BirthPlaceSortParam = sortOrder == "birthPlace" ? "birthPlace_desc" : "birthPlace";
            if (queryString != null)
                page = 1;
            else
                queryString = currentFilter;

            ViewBag.CurrentFilter = queryString;
            var writers = dbLogic.GetAllWriters();
            if (!String.IsNullOrEmpty(queryString))
            {
                writers = writers.Where(s => s.WriterName.Contains(queryString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    writers = writers.OrderByDescending(t => t.WriterName);
                    break;
                case "name":
                    writers = writers.OrderBy(t => t.WriterName);
                    break;
                case "birthPlace_desc":
                    writers = writers.OrderByDescending(t => t.PlaceOfBirth);
                    break;
                case "birthPlace":
                    writers = writers.OrderBy(t => t.PlaceOfBirth);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(writers.ToPagedList(pageNumber, pageSize));
        }
        #endregion
        #endregion

        #region Remove
        #region removeActor
        public ActionResult RemoveActorFromMovie(int? MovieId, int? ActorId)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            Movie m = dbLogic.GetMovieById((int)MovieId);
            Actor a = dbLogic.GetActorById((int)ActorId);
            ViewBag.movieName = m.MovieName;
            ViewBag.movieId = MovieId;
            ViewBag.actorName = a.ActorName;
            ViewBag.actorId = ActorId;
            return View();

        }
        [HttpPost, ActionName("RemoveActorFromMovie")]
        public ActionResult ConfirmRemoveActorFromMovie(int MovieId, int ActorId)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            dbLogic.GetMovieById(MovieId).Actor.Remove(dbLogic.GetActorById(ActorId));
            dbLogic.SaveChanges();
            return RedirectToAction("GetAllMovies", "Movie");

        }

        public ActionResult RemoveActorsFromMovie(int id, string sortOrder, string queryString, string currentFilter, int? page)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            Movie m = dbLogic.GetMovieById(id);
            ViewBag.movieId = id;
            var actor = dbLogic.GetActorsByMovieId(id);
            return View(actor);
        }
        #endregion

        #region RemoveDirector
        public ActionResult RemoveDirectorFromMovie(int? MovieId, int? DirectorId)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            Movie m = dbLogic.GetMovieById((int)MovieId);
            Director a = dbLogic.GetDirectorById((int)DirectorId);
            ViewBag.movieName = m.MovieName;
            ViewBag.movieId = MovieId;
            ViewBag.directorName = a.DirectorName;
            ViewBag.directorId = DirectorId;
            return View();

        }
        [HttpPost, ActionName("RemoveDirectorFromMovie")]
        public ActionResult ConfirmRemoveDirectorFromMovie(int MovieId, int DirectorId)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            dbLogic.GetMovieById(MovieId).Director.Remove(dbLogic.GetDirectorById(DirectorId));
            dbLogic.SaveChanges();
            return RedirectToAction("GetAllMovies", "Movie");

        }

        public ActionResult RemoveDirectorsFromMovie(int id, string sortOrder, string queryString, string currentFilter, int? page)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            Movie m = dbLogic.GetMovieById(id);
            ViewBag.movieId = id;
            var actor = dbLogic.GetDirectorsByMovieId(id);
            return View(actor);
        }
        #endregion

        #region RemoveWriter
        public ActionResult RemoveWriterFromMovie(int? MovieId, int? WriterId)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            Movie m = dbLogic.GetMovieById((int)MovieId);
            Writer a = dbLogic.GetWriterById((int)WriterId);
            ViewBag.movieName = m.MovieName;
            ViewBag.movieId = MovieId;
            ViewBag.writerName = a.WriterName;
            ViewBag.writerId = WriterId;
            return View();

        }
        [HttpPost, ActionName("RemoveWriterFromMovie")]
        public ActionResult ConfirmRemoveWriterFromMovie(int MovieId, int WriterId)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            dbLogic.GetMovieById(MovieId).Writer.Remove(dbLogic.GetWriterById(WriterId));
            dbLogic.SaveChanges();
            return RedirectToAction("GetAllMovies", "Movie");

        }

        public ActionResult RemoveWritersFromMovie(int id, string sortOrder, string queryString, string currentFilter, int? page)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            Movie m = dbLogic.GetMovieById(id);
            ViewBag.movieId = id;
            var actor = dbLogic.GetWritersByMovieId(id);
            return View(actor);
        }
        #endregion


        #endregion


        public ActionResult ChangeMovieCast(int? id)
        {
            if (!isAdminUser())
            {
                return RedirectToAction("GetAllMovies", "Movie");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = dbLogic.GetMovieById((int)id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        #endregion


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
