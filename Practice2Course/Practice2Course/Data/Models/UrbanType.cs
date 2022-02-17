using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2Course.Data.Models
{
    // Класс с типами городских объектов
    public class UrbanType
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

    }
}
