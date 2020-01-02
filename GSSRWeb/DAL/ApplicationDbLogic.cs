using GSSRWebMovies.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GSSRWeb.DAL
{
    public class ApplicationDbLogic
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        #region Role
        #region Get
        public List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> GetAllRoles()
        {
            return db.Roles.ToList();
        }
        public IdentityRole GetRoleById(string id)
        {
            return db.Roles.Where(a => a.Id == id).FirstOrDefault();
        }

        #endregion

        #region Update
        public void UpdateRole(IdentityRole m)
        {
            db.Entry(m).State = EntityState.Modified;
        }
        public void AddRole(IdentityRole m)
        {
            db.Roles.Add(m);
        }
        public void DeleteRole(IdentityRole m)
        {
            db.Roles.Remove(m);
        }
        #endregion
        #endregion

        #region User
        #region Get
        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return db.Users;
        }
        public ApplicationUser GetUserById(string id)
        {
            return db.Users.Where(a => a.Id == id).FirstOrDefault();
        }
        #endregion

        #region Update
        public void UpdateUser(IdentityUser m)
        {
            db.Entry(m).State = EntityState.Modified;
        }
        public void AddUser(ApplicationUser m)
        {
            db.Users.Add(m);
        }
        public void DeleteUser(ApplicationUser m)
        {
            db.Users.Remove(m);
        }
        #endregion
        #endregion
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}