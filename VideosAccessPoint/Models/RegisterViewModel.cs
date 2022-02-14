using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideosAccessPoint.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Логін")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare ("Password", ErrorMessage ="Паролі не співпадають")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторіть пароль")]
        public string PasswordConfirm { get; set; }
    }
}
