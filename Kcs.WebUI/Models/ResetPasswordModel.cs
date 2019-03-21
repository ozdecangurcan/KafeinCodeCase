using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kcs.WebUI.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "EMail Girişi Zorunludur.")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Hatalı Mail Adresi")]
        [Display(Name = "EMail")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Şifre Girişi Zorunludur.")]
        [MaxLength(8, ErrorMessage = "En Fazla 8 Karakter Girilmelidir.")]
        [MinLength(8, ErrorMessage = "En Az 8 Karakter Girilmelidir.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
