using System;
using System.Collections.Generic;
using System.Linq;
using SmartBook.Models;
using System.Data.Entity;
using Website.Models;
using SmartBook.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;
using Website.ViewModels;
namespace SmartBook.DAL
{
    public class SmartBookWebLogic
    {
       
            private SmartBookWebContext db = new SmartBookWebContext();
            #region Movies
            #region Get
            public IQueryable<Book> GetAllBook()
            {

                return db.Book;
            }
            public Book GetBookById(int Id)
            {
                return db.Book.FirstOrDefault();
            }


            #endregion

            #region Update
            public void UpdateMovie(Book m)
            {
                db.Entry(m).State = EntityState.Modified;
            }
            public void AddMovie(Book m)
            {
                db.Book.Add(m);
            }
            public void DeleteMovie(Book m)
            {
                db.Book.Remove(m);
            }
            #endregion
            #endregion

            #region Writer
            #region Get
            public IQueryable<Writer> GetAllWriters()
            {
                return db.Writer.Include(m => m.Book);
            }
            public ICollection<Writer> GetWritersByMovieId(int BookId)
            {
                return db.Book.Where(a => a.BookId == BookId).FirstOrDefault().Writer;
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
            public double GetBookRating(int id)
            {
                double reviewSum = db.Review.Where(a => a.BookId == id).Sum(a => a.ReviewRating);
                double numOfRevies = db.Review.Where(a => a.BookId == id).Count();
                if (numOfRevies == 0)
                    return 0;
                return reviewSum / numOfRevies;
            }
            public Review GetReviewById(int reviewId)
            {
                Review rev = db.Review.Where(m => m.ReviewId == reviewId).Join(db.Book, r => r.BookId, m => m.BookId, (r, m) => new Review { Book = m, BookId = m.  BookId, ReviewId = r.ReviewId, ReviewDate = r.ReviewDate, ReviewRating = r.ReviewRating, ReviewText = r.ReviewText, UserName = r.UserName }).FirstOrDefault();
                return rev;
                //return db.Review.Where(m => m.ReviewId == reviewId).FirstOrDefault();
            }

            public IQueryable<Review> GetAllReviews()
            {
                IQueryable<Review> rev = db.Review.Join(db.Book, r => r.BookId, m => m.BookId, (r, m) => new Review { Book = m, BookId = m.BookId, ReviewId = r.ReviewId, ReviewDate = r.ReviewDate, ReviewRating = r.ReviewRating, ReviewText = r.ReviewText, UserName = r.UserName });
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
            public void AddBookVisit(int BookId, string userName)
            {
                UserBookVisits us = new UserBookVisits();
                us.MovieIdVisit = BookId;
                us.UserName = userName;
                us.VisitDate = DateTime.Now;
                db.UserBookVisits.Add(us);
            }



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
    
