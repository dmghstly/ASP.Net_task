using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2Course.Data.Models
{
    public class RoadType
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
