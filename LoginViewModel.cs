using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_employee.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Login Id")]
        public int loginid { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}