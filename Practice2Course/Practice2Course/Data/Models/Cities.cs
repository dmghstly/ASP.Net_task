using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2Course.Data.Models
{
    public class Cities
    {
        [Key]
        public int CityId { get; set; }

        [Display(Name = "Наименование:")]
        [StringLength(40)]
        [Required(ErrorMessage = "Не менее 1 и не более 40 символов")]
        public string CityName { get; set; }

        [Display(Name = "Ссылка на картинку:")]
        public string ImgUrl { get; set; }

        [Display(Name = "Ссылка на карту:")]
        [Url]
        public string MapUrl { get; set; }

        [Display(Name = "Описание:")]
        public string Description { get; set; }

        [Display(Name = "Страна:")]
        [Required (ErrorMessage = "Выберите страну из списка или создайте, если таковых нет")]
        public int CountryId { get; set; }
        public Countries Country { get; set; }

        public static int CompareByName(Cities city1, Cities city2)
        {
            return String.Compare(city1.CityName, city2.CityName);
        }
    }
}
