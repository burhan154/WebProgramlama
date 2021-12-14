using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Models
{
    public class OrderDetails
    {
        [Required(ErrorMessage = "Lütfen bir adres tanimi giriniz.")]
        public string AdresTanimi { get; set; }

        [Required(ErrorMessage = "Lütfen bir adres giriniz.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen bir Sehir adi giriniz.")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen bir Semt adi giriniz.")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Lütfen bir telefon numarasi giriniz.")]
        public string Telefon { get; set; }

    }
}
