using Practice2Course.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2Course.Data
{
    // Вспомогательные переменные
    public class HelpElements
    {
        // Id города
        public static int HelpCityID;

        // Id улицы
        public static int HelpStreetID;

        // Страна
        public static Countries country = new Countries();

        // Город
        public static Cities city = new Cities();

        // Улица
        public static RoadSystem road = new RoadSystem();

        // Городской объект
        public static UrbanObject uObject = new UrbanObject();

        // Список стран
        public static Dictionary<int, string> CountriesDictionary = new Dictionary<int, string>();

        // Список городов
        public static Dictionary<int, string> CitiesDictionary = new Dictionary<int, string>();

        // Список типов объектов
        public static Dictionary<int, string> UrbanTypesDictionary = new Dictionary<int, string>();

        // Список типов улиц
        public static Dictionary<int, string> RoadTypesDictionary = new Dictionary<int, string>();

        // Список улиц по городам
        public static Dictionary<int, Dictionary<int, string>> StreetDictionary = new Dictionary<int, Dictionary<int, string>>();

        // Список сокращений
        public static Dictionary<int, string> Abbs = new Dictionary<int, string>();

        // Создание списка со странами
        public static void MakeCountriesDictionary(UPISContext db)
        {
            CountriesDictionary = new Dictionary<int, string>();
            var list = db.AllCountries.ToList();
            foreach (var el in list)
            {
                CountriesDictionary.Add(el.CountryId, el.CountryName);
            }
            CountriesDictionary = CountriesDictionary.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        // Создание списка с городами
        public static void MakeCitiesDictionary(UPISContext db)
        {
            CitiesDictionary = new Dictionary<int, string>();
            var list = db.AllCities.ToList();
            foreach (var el in list)
            {
                CitiesDictionary.Add(el.CityId, el.CityName + ", " + CountriesDictionary[el.CountryId]);
            }
            CitiesDictionary = CitiesDictionary.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        // Создание списка с разными типами
        public static void MakeTypesDictionary(UPISContext db)
        {
            UrbanTypesDictionary = new Dictionary<int, string>();
            RoadTypesDictionary = new Dictionary<int, string>();
            var listObjeccts = db.AllUrbanTypes.ToList();
            var listRoads = db.AllRoadTypes.ToList();
            foreach (var el in listObjeccts)
            {
                UrbanTypesDictionary.Add(el.TypeId, el.TypeName);
            }
            foreach (var el in listRoads)
            {
                RoadTypesDictionary.Add(el.TypeId, el.TypeName);
            }
        }

        // Создание списка сокращений
        public static void MakeAbbsDictionary()
        {
            Abbs = new Dictionary<int, string>();
            Abbs.Add(7, "ул.");
            Abbs.Add(8, "переулок");
            Abbs.Add(9, "пр.");
            Abbs.Add(10, "ш.");
            Abbs.Add(11, "проезд");
            Abbs.Add(12, "б-р");
            Abbs.Add(13, "дорога");
            Abbs.Add(15, "ав.");
            Abbs.Add(16, "пл.");
        }

        // Список улиц
        public static void MakeStreetDictionary(UPISContext db)
        {
            StreetDictionary = new Dictionary<int, Dictionary<int, string>>();
            var streets = db.AllRoads.ToList();
            foreach (var el in streets)
            {
                if (StreetDictionary.ContainsKey(el.CityId))
                    if (el.StreetName == "-")
                        StreetDictionary[el.CityId].Add(el.StreetId, el.StreetName);
                    else
                        StreetDictionary[el.CityId].Add(el.StreetId, Abbs[el.TypeId] + " " + el.StreetName);
                else
                {
                    if (el.StreetName == "-")
                    {
                        StreetDictionary.Add(el.CityId, new Dictionary<int, string>());
                        StreetDictionary[el.CityId].Add(el.StreetId, el.StreetName);
                    }
                    else
                    {
                        StreetDictionary.Add(el.CityId, new Dictionary<int, string>());
                        StreetDictionary[el.CityId].Add(el.StreetId, Abbs[el.TypeId] + " " + el.StreetName);
                    }
                }
                StreetDictionary[el.CityId] = StreetDictionary[el.CityId].OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }          
    }
}
