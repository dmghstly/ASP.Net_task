using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2Course.Data
{
    public class RoadFilters
    {
        // Все фильтры
        public bool All { get; set; }
        // Фильтр "улица"
        public bool UlFilter { get; set; }
        // Фильтр "переулок"
        public bool PereUlFilter { get; set; }
        // Фильтр "проспект"
        public bool ProsFilter { get; set; }
        // Фильтр "шоссе"
        public bool ShosFilter { get; set; }
        // Фильтр "проезд"
        public bool ProezdFilter { get; set; }
        // Фильтр "бульвар"
        public bool BoulFilter { get; set; }
        // Фильтр "дорога"
        public bool DorFilter { get; set; }
        // Фильтр "авеню"
        public bool AveFilter { get; set; }
        // Фильтр "площадь"
        public bool PlFilter { get; set; }
    }
}
