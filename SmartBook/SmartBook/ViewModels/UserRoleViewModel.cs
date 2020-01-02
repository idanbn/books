using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.ViewModels
{
    public class UserRoleViewModel
    {
        public string Id { get; set; }
        [Display(Name = "User Name")]
        [StringLength(30, ErrorMessage = "Username must be under 30 characters")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Must be a valid email address")]
        public string Email { get; set; }
        [Display(Name = "Role")]
        public string RoleId { get; set; }
    }
}