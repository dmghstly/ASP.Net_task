using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2Course.Data.Models
{
    public class UrbanObject
    {
        [Key]
        public int ObjectId { get; set; }

        [Display(Name = "Наименование:")]
        [StringLength(40)]
        [Required(ErrorMessage = "Не менее 1 и не более 40 символов")]
        public string ObjectName { get; set; }

        [Display(Name = "Номер объекта в адресе:")]
        public string Number { get; set; }

        [Display(Name = "Ссылка на картинку:")]
        public string ImgUrl { get; set; }

        [Display(Name = "Ссылка на карту:")]
        [Url]
        public string MapUrl { get; set; }

        [Display(Name = "Описание:")]
        public string Description { get; set; }

        [Display(Name = "Адрес:")]
        public string Addres { get; set; }

        [Display(Name = "Тип:")]
        [Required]
        public int TypeId { get; set; }
        public UrbanType uType { get; set; }

        [Display(Name = "Улица:")]
        [Required(ErrorMessage = "Выберите улицу из списка или создайте, если таковых нет")]
        public int StreetId { get; set; }
        public RoadSystem Street { get; set; }

        public static int CompareByName(UrbanObject object1, UrbanObject object2)
        {
            return String.Compare(object1.ObjectName, object2.ObjectName);
        }
    }
}
