using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2Course.Data
{
    // фильтры
    public class UrbanFilters
    {
        // Все 
        public bool All { get; set; }
        // Инженерная постройка
        public bool IngFilter { get; set; }
        // Транспортный объект
        public bool TranspFilter { get; set; }
        // Социаьная постройка
        public bool SocFilter { get; set; }
        // Объект природы
        public bool NatFilter { get; set; }
        // Производственная постройка
        public bool ProdFilter { get; set; }
        // Жилая постройка
        public bool LivFilter { get; set; }
        // культурный объект
        public bool CultFilter { get; set; }
        // Тип коммуникаций
        public bool CommFilter { get; set; }
    }
}
