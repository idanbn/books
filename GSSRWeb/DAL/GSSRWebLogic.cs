using GSSRWeb.Models;
using GSSRWeb.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Website.Models;
using Website.ViewModels;

namespace GSSRWeb.DAL
{
    public class GSSRWebLogic
    {
        private GSSRWebContext db = new GSSRWebContext();
        #region Movies
        #region Get
        public IQueryable<Movie> GetAllMovies()
        {

            return db.Movie.Include(m => m.Genre);
        }
        public Movie GetMovieById(int Id)
        {
            return db.Movie.Include(m => m.Genre).Where(m => m.MovieId == Id).FirstOrDefault();
        }
        public int GetCountOfMoviesByGenre(int genreId)
        {
            return db.Movie.Where(r => r.GenreId == genreId).Count();
        }

        public IQueryable<Movie> GetMoviesByGenreId(int genreId) {
            return db.Movie.Where(r => r.GenreId == genreId);
        }
        public IQueryable<Movie> GetMoviesByActorId(int actorId)
        {
            var emp = GetActorById(actorId);
            return db.Movie.Where(m => m.Actor.Contains(emp));

        }


        #endregion

        #region Update
        public void UpdateMovie(Movie m)
        {
            db.Entry(m).State = EntityState.Modified;
        }
        public void AddMovie(Movie m)
        {
            db.Movie.Add(m);
        }
        public void DeleteMovie(Movie m)
        {
            db.Movie.Remove(m);
        }
        #endregion
        #endregion

        #region MoviesGenre
        #region Get
        public LinkedList<MoviesCountByGenre> GetCountOfMoviesByGenre()
        {
            LinkedList<MoviesCountByGenre> mcbg = new LinkedList<MoviesCountByGenre>();
            foreach (Genre g in db.Genre.ToList())
            {
                MoviesCountByGenre m = new MoviesCountByGenre();
                m.GenreId = g.GenreId;
                m.GenreName = g.GenreName;
                m.countOfMovies = GetCountOfMoviesByGenre(g.GenreId);
                mcbg.AddLast(m);
            }
            return mcbg;
        }
        public IQueryable<Genre> GetAllGenres()
        {
            return db.Genre;
        }
        public Genre GetGenreById(int genreId)
        {
            return db.Genre.Where(m => m.GenreId == genreId).FirstOrDefault();
        }
        #endregion

        #region Update
        public void DeleteGenre(Genre g)
        {
            db.Genre.Remove(g);
        }
        public void AddGenre(Genre g)
        {
            db.Genre.Add(g);
        }
        public void UpdateGenre(Genre g)
        {
            db.Entry(g).State = EntityState.Modified;
        }
        #endregion
        #endregion

        #region Actor
        #region Get
        public IQueryable<Actor> GetAllActors()
        {
            return db.Actor.Include(m => m.Movie);
        }
        public ICollection<Actor> GetActorsByMovieId(int MovieId)
        {
            return db.Movie.Where(a => a.MovieId==MovieId).FirstOrDefault().Actor;
        }
        public Actor GetActorById(int ActorId)
        {
            return db.Actor.Where(m => m.ActorId == ActorId).FirstOrDefault();
        }
        #endregion

        #region Update
        public void DeleteActor(Actor e)
        {
            db.Actor.Remove(e);
        }
        public void AddActor(Actor e)
        {
            db.Actor.Add(e);
        }
        public void UpdateActor(Actor e)
        {
            db.Entry(e).State = EntityState.Modified;
        }
        #endregion
        #endregion

        #region ActorLocation
        #region Get
        public ActorLocation GetActorLocation(int actorId)
        {
            return db.ActorLocation.Where(a => a.ActorId == actorId).FirstOrDefault();
        }
        #endregion

        #region Update
        public void DeleteActorLocation(ActorLocation e)
        {
            db.ActorLocation.Remove(e);
        }
        public void AddActorLocation(ActorLocation e)
        {
            db.ActorLocation.Add(e);
        }
        public void UpdateActorLocation(ActorLocation e)
        {
            db.Entry(e).State = EntityState.Modified;
        }
        #endregion
        #endregion

        #region Director
        #region Get
        public IQueryable<Director> GetAllDirectors()
        {
            return db.Director.Include(m => m.Movie);
        }
        public ICollection<Director> GetDirectorsByMovieId(int MovieId)
        {
            return db.Movie.Where(a => a.MovieId == MovieId).FirstOrDefault().Director;
        }
        public Director GetDirectorById(int DirectorId)
        {
            return db.Director.Where(m => m.DirectorId == DirectorId).FirstOrDefault();
        }
        #endregion
        #region Update
        public void DeleteDirector(Director e)
        {
            db.Director.Remove(e);
        }
        public void AddDirector(Director e)
        {
            db.Director.Add(e);
        }
        public void UpdateDirector(Director e)
        {
            db.Entry(e).State = EntityState.Modified;
        }
        #endregion
        #endregion

        #region Writer
        #region Get
        public IQueryable<Writer> GetAllWriters()
        {
            return db.Writer.Include(m => m.Movie);
        }
        public ICollection<Writer> GetWritersByMovieId(int MovieId)
        {
            return db.Movie.Where(a => a.MovieId == MovieId).FirstOrDefault().Writer;
        }
        public Writer GetWriterById(int WriterId)
        {
            return db.Writer.Where(m => m.WriterId == WriterId).FirstOrDefault();
        }
        #endregion
        #region Update
        public void DeleteWriter(Writer e)
        {
            db.Writer.Remove(e);
        }
        public void AddWriter(Writer e)
        {
            db.Writer.Add(e);
        }
        public void UpdateWriter(Writer e)
        {
            db.Entry(e).State = EntityState.Modified;
        }
        #endregion
        #endregion

        #region Review
        #region Get
        public double GetMovieRating(int id)
        {
            double reviewSum = db.Review.Where(a => a.MovieId == id).Sum(a => a.ReviewRating);
            double numOfRevies = db.Review.Where(a => a.MovieId == id).Count();
            if (numOfRevies == 0)
                return 0;
            return reviewSum/numOfRevies;
        }
        public Review GetReviewById(int reviewId)
        {
            Review rev = db.Review.Where(m => m.ReviewId == reviewId).Join(db.Movie, r => r.MovieId, m => m.MovieId, (r, m) => new Review { Movie = m, MovieId = m.MovieId, ReviewId = r.ReviewId, ReviewDate = r.ReviewDate, ReviewRating = r.ReviewRating, ReviewText = r.ReviewText, UserName = r.UserName }).FirstOrDefault();
            return rev;
            //return db.Review.Where(m => m.ReviewId == reviewId).FirstOrDefault();
        }

        public IQueryable<Review> GetAllReviews()
        {
            IQueryable<Review> rev = db.Review.Join(db.Movie, r => r.MovieId, m => m.MovieId, (r, m) => new Review { Movie = m, MovieId = m.MovieId, ReviewId = r.ReviewId, ReviewDate = r.ReviewDate, ReviewRating = r.ReviewRating, ReviewText = r.ReviewText, UserName = r.UserName });
            return rev;
            //return db.Review.Include(m => m.Movie);
        }
        #endregion
        #region Update

        public void AddReview(Review r)
        {
            db.Review.Add(r);
        }

        public void DeleteReview(Review r)
        {
            db.Review.Remove(r);
        }

        #endregion
        #endregion

        #region Pictures
        #region Get
        public IQueryable<Picture> GetAllPictures()
        {
            return db.Picture;
        }
       
      
        public Picture GetPictureById(int PictureId)
        {
            return db.Picture.Where(m => m.PictureId == PictureId).FirstOrDefault();
        }
        #endregion
        #region Update
        public void DeletePicture(Picture e)
        {
            db.Picture.Remove(e);
        }
        public void AddPicture(Picture e)
        {
            db.Picture.Add(e);
        }
        public void UpdatePicture(Picture e)
        {
            db.Entry(e).State = EntityState.Modified;
        }
        #endregion
        #endregion

        #region General

        #region UserStatistics
        public void AddMovieVisit(int movieId,string userName)
        {
            UserMovieVisits us = new UserMovieVisits();
            us.MovieIdVisit = movieId;
            us.UserName = userName;
            us.VisitDate = DateTime.Now;
            db.UserMovieVisits.Add(us);
        }


        public IEnumerable<Movie> GetMostVisitedMovies()
        {
            List<int> movieList = db.UserMovieVisits.OrderByDescending(a => db.UserMovieVisits.Where(b => b.MovieIdVisit == a.MovieIdVisit).Count())
                    .Select(c => c.MovieIdVisit).Distinct().Take(3).ToList();
            return db.Movie.Where(a => movieList.Contains(a.MovieId));
        }
        public IEnumerable<Movie> GetMostVisitedMoviesByUsername(string userName)
        {
            List<int> movieList = db.UserMovieVisits.Where(a=>a.UserName == userName)
                .OrderByDescending(a => db.UserMovieVisits.Where(b => b.MovieIdVisit == a.MovieIdVisit && b.UserName == a.UserName).Count())
                .Select(c => c.MovieIdVisit).Distinct().Take(3).ToList();
            return db.Movie.Where(a => movieList.Contains(a.MovieId));
        }

        public void AddActorVisit(int actorId, string userName)
        {
            UserActorVisits ua = new UserActorVisits();
            ua.ActorIdVisit = actorId;
            ua.UserName = userName;
            ua.VisitDate = DateTime.Now;
            db.UserActorVisits.Add(ua);
        }

        public IEnumerable<Movie> GetIntrestingMoviesByActors(string userName)
        {
            List<int> actorList = db.UserActorVisits.Where(a => a.UserName == userName)
                .OrderByDescending(a => db.UserActorVisits.Where(b => b.ActorIdVisit == a.ActorIdVisit && b.UserName == a.UserName).Count())
                .Select(c => c.ActorIdVisit).Distinct().Take(3).ToList();
            IEnumerable<Actor> actors = db.Actor.Where(a => actorList.Contains(a.ActorId));
            return db.Movie.Where(m => m.Actor.Any(a => actors.Contains(a)));
        }


        public List<ReviewTracker> GetReviewsCountByMonthStatistic()
        {
            List<ReviewTracker> list = db.Review.GroupBy(r => new { r.ReviewDate.Year, r.ReviewDate.Month })
                .Select(g => new ReviewTracker
                {
                    Year = g.Key.Year,
                    Month =g.Key.Month,
                    NumOfReviews = g.Count()
                }).ToList();
            return list;
        }
        #endregion
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        #endregion


    }
}
