using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kcs.WebUI.Models
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }

        [Required(ErrorMessage = "İsim Girişi Zorunludur.")]
        [Display(Name = "Ad")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Soyisim Girişi Zorunludur.")]
        [Display(Name = "Soyad")]
        public string PersonSurname { get; set; }

        [Required(ErrorMessage = "EMail Girişi Zorunludur.")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Hatalı Mail Adresi")]
        [Display(Name = "EMail")]
        public string PersonEmail { get; set; }

        [Required(ErrorMessage = "Telefon Girişi Zorunludur.")]
        [MaxLength(11, ErrorMessage = "11 Haneli Telefon Numarası Giriniz")]
        [MinLength(11, ErrorMessage = "11 Haneli Telefon Numarası Giriniz")]
        [Display(Name = "Telefon")]
        public string PersonPhone { get; set; }

        [Required(ErrorMessage = "Doğum Tarihi Girişi Zorunludur.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Doğum Tarihi")]
        public DateTime PersonBirthday { get; set; }

        [Required(ErrorMessage = "İl Seçimi Zorunludur.")]
        [Display(Name = "İl")]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "İlçe Seçimi Zorunludur.")]
        [Display(Name = "İlçe")]
        public int DistrictId { get; set; }
    }
}
