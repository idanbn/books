using SmartBook.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models;

namespace SmartBook.DAL
{
    public class SmartBookWebContext: IdentityDbContext
    {
        

     
            public SmartBookWebContext() : base("SmartBookWebContext") { }
            public DbSet<Book> Book { get; set; }
            public DbSet<Review> Review { get; set; }
            public DbSet<Writer> Writer { get; set; }
            public DbSet<Picture> Picture { get; set; }
        public object UserBookVisits { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }



            //public System.Data.Entity.DbSet<Website.ViewModels.MovieDetails> MovieDetails { get; set; }
        }
    }

