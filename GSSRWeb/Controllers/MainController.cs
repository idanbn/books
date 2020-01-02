using GSSRWeb.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace GSSRWeb.Controllers
{
    public class MainController : Controller
    {
        private GSSRWebLogic dbLogic = new GSSRWebLogic();
        private static readonly HttpClient client = new HttpClient();
        // GET: Main
        public ActionResult Index()
        {
            // Get user's visited movies
            List<Movie> visitedMovies = dbLogic.GetMostVisitedMoviesByUsername(User.Identity.Name).ToList();
            if (visitedMovies.Count > 0)
            {
                Random rand = new Random();
                int guess = rand.Next(0, visitedMovies.Count());
                // Movies with the same genre
                List<Movie> recommendedMovies = dbLogic.GetMoviesByGenreId(visitedMovies[guess].GenreId).ToList();
                // Movie that created the recommendation
                this.ViewBag.RecommendedBecause = visitedMovies.ElementAt(guess);
                // Remove the movie so it wont appear twice
                recommendedMovies.Remove(visitedMovies.ElementAt(guess));

                // Calculate the average review of this genre without this movie
                double sum = 0.0;
                double count = 0.0;
                recommendedMovies.ForEach(m =>
                {
                    foreach (Review r in m.Review)
                    {
                        sum += r.ReviewRating;
                        count++;
                    }
                });

                this.ViewBag.avgGenreRating = (sum / count);


                guess = rand.Next(0, recommendedMovies.Count());
                this.ViewBag.RecommendedMovie = recommendedMovies.ElementAt(guess);
                List<Review> reviews = recommendedMovies.ElementAt(guess).Review.ToList();
                List<int> ratings = new List<int>();
                reviews.ForEach(r => ratings.Add(r.ReviewRating));

                // Calculate specific movie's average
                sum = 0.0;
                count = 0.0;
                ratings.ForEach(r =>
                {
                    sum += r;
                    count++;
                });
                this.ViewBag.movieAvgRating = (sum / count);

                // Count the ratings for the graph
                int[] ratingCount = new int[5];
                ratings.ForEach(r =>
                {
                    ratingCount[r - 1]++;
                });
                this.ViewBag.ratings = ratingCount.ToList();

            }

            // Get 4 latest added movies
            List<Movie> Movies = dbLogic.GetAllMovies().OrderByDescending(m => m.YearOfPublish).Take(4).ToList();
            List<Movie> highestRated = dbLogic.GetAllMovies().OrderByDescending(m => (m.Review.Sum(r => r.ReviewRating) / m.Review.Count())).Take(3).ToList();
            Movies.AddRange(highestRated);
            return View(Movies);
        }

        // GET: Main/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Main/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Main/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Main/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Main/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public static async void foo()
        {
           // Debug.Write("foo Happened");
            var values = new Dictionary<string, string>
                {
                { "thing1", "hello" },
                { "thing2", "world" }
                };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }
    }
}
