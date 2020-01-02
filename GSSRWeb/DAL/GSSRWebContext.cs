using GSSRWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Website.Models;

namespace GSSRWeb.DAL
{
    public class GSSRWebContext : IdentityDbContext
    {
        public GSSRWebContext() : base("GSSRWebContext") { }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<ActorLocation> ActorLocation { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Writer> Writer { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<UserMovieVisits> UserMovieVisits { get; set; }
        public DbSet<UserActorVisits> UserActorVisits { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }



        //public System.Data.Entity.DbSet<Website.ViewModels.MovieDetails> MovieDetails { get; set; }
    }
}