using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideosAccessPoint.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="логін")]
        public string UserName { get; set; }
        [Required]
        [UIHint("password")]
        [Display(Name = "пароль")]
        public string Password { get; set; }

        [Display(Name = "запам'ятати мене?")]
        public bool RememberMe { get; set; }
    }
}
