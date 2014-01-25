using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ScheduleOfFaculty.Models
{

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
    public class AuthorizeActiveDirectoryAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            
            var user = filterContext.HttpContext.User;

            //Your code to get the list of roles for the current user

            var formsIdentity = filterContext.HttpContext.User.Identity as FormsIdentity;

            List<String> roles = new List<String>();
            roles.Add("Admin");
            roles.Add("User");
            roles.Add("DefaultUser");
            filterContext.HttpContext.User = new System.Security.Principal.GenericPrincipal(formsIdentity, roles.ToArray());

            base.OnAuthorization(filterContext);
        }

    }
    

}
