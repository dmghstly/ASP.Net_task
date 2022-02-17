using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2Course.Data.Models
{
    public class FileName
    {
        [Display(Name = "Наименование файла:")]
        [StringLength(40)]
        [Required(ErrorMessage = "Заполните поле")]
        public string Name { get; set; }
    }
}
