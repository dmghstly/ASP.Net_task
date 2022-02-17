using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2Course.Data.Models
{
    public class RoadSystem
    {
        [Key]
        public int StreetId { get; set; }

        [Display(Name = "Наименование:")]
        [StringLength(40)]
        [Required(ErrorMessage = "Не менее 1 и не более 40 символов")]
        public string StreetName { get; set; }

        [Display(Name = "Ссылка на картинку:")]
        public string ImgUrl { get; set; }

        [Display(Name = "Ссылка на карту:")]
        [Url]
        public string MapUrl { get; set; }

        [Display(Name = "Описание:")]
        public string Description { get; set; }

        [Display(Name = "Тип:")]
        [Required]
        public int TypeId { get; set; }
        public RoadType rType { get; set; }

        [Display(Name = "Город:")]
        [Required(ErrorMessage = "Выберите город из списка или создайте, если таковых нет")]
        public int CityId { get; set; }
        public Cities City { get; set; }

        public static int CompareByName(RoadSystem road1, RoadSystem road2)
        {
            return String.Compare(road1.StreetName, road2.StreetName);
        }
    }
}
