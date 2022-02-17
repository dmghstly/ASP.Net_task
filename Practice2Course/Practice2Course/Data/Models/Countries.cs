using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2Course.Data.Models
{
    public class Countries
    {
        [Key]
        public int CountryId { get; set; }

        [Display(Name = "Наименование:")]
        [StringLength(40)]
        [Required(ErrorMessage = "Не менее 1 и не более 40 символов")]       
        public string CountryName { get; set; }

        [Display(Name = "Ссылка на картинку:")]
        public string ImgUrl { get; set; }

        [Display(Name = "Cсылка на карту:")]
        [Url]
        public string MapUrl { get; set; }

        [Display(Name = "Описание:")]
        public string Description { get; set; }

        public static int CompareByName(Countries country1, Countries country2)
        {
            return String.Compare(country1.CountryName, country2.CountryName);
        }
    }
}
