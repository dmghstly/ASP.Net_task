using Practice2Course.Data;
using Practice2Course.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2Course
{
    public static class Sample
    {
        // Создание объектов базы данных
        public static void Initialize(UPISContext context)
        {
            if (!context.AllCountries.Any())
            {
                context.AllCountries.AddRange(new Countries { }); 
            }

            if (!context.AllCities.Any())
            {
                context.AllCities.AddRange(new Cities { });
            }
            if (!context.AllUrbanObjects.Any())
            {
                context.AllUrbanObjects.AddRange(new UrbanObject { });
            }

            if (!context.AllRoads.Any())
            {
                context.AllRoads.AddRange(new RoadSystem { });
            }
            if (!context.AllUrbanTypes.Any())
            {
                context.AllUrbanTypes.AddRange(
                new UrbanType
                {
                    TypeName = "Объект инженерной инфраструктуры",
                    Description = "Объект, обеспечивающий объекты жилищно–гражданского и " +
                "производственного назначения, централизованными системами водоснабжения, канализации, дождевой канализации, теплоснабжения, " +
                "энергоснабжения, газоснабжения, телефонизации и связи."
                },
                new UrbanType
                {
                    TypeName = "Объект транспортной инфраструктуры",
                    Description = "Объект транспортной системы, обеспечивающий транспортное " +
                "обслуживание населения и перевозку грузов."
                },
                new UrbanType
                {
                    TypeName = "Объект социальной инфраструктуры",
                    Description = "Объект, обеспечивающий потребности человека в получении, приобретении жизненно важных услуг, продуктов, товаров."
                },
                new UrbanType
                {
                    TypeName = "Природная территория",
                    Description = "Территория, выполняющая санитарно–защитные и водоохранные функции, формирующие микроклимат и своеобразный климат города."
                },
                new UrbanType
                {
                    TypeName = "Производственная территория",
                    Description = "Территория, предназначенная, для размещения производственно–деловых, транспортных и инженерных объектов."
                },
                new UrbanType
                {
                    TypeName = "Жилая территория",
                    Description = "Территория, предназначенная для организации жилой среды, отвечающей современным социальным, гигиеническим и градостроительным требованиям."
                },
                new UrbanType
                {
                    TypeName = "Объект культурного наследия",
                    Description = "Объект историко–культурного назначения."
                }
                );
            }

            if (!context.AllRoadTypes.Any())
            {
                context.AllRoadTypes.AddRange(
                new RoadType { TypeName = "Улица" },
                new RoadType { TypeName = "Проспект" },
                new RoadType { TypeName = "Шоссе" },
                new RoadType { TypeName = "Бульвар" },
                new RoadType { TypeName = "Переулок" },
                new RoadType { TypeName = "Проезд" },
                new RoadType { TypeName = "Дорога" }
                );
            }
            context.SaveChanges();
        }
    }
}
