using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VC.UIModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="User Name Is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Password Is Required")]
        [StringLength(30, MinimumLength=6)]
        public string Password { get; set; }
    }
}