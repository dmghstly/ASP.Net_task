using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practice2Course.Data;
using Practice2Course.Data.Models;

namespace Practice2Course.Controllers
{
    public class SearchController : Controller
    {
        public UPISContext db;
        public SearchController(UPISContext context)
        {
            db = context;
        }
        //--------------------------------------------------------------
        // Контроллеры для поиска страны
        public IActionResult CountrySearch()
        {
            ViewBag.Title = "Поиск страны по имени";
            return View();
        }

        // Передача страны дейтсвию по выводу результата
        [HttpPost]
        public IActionResult CountrySearch(Countries country)
        {
            HelpElements.country = country;
            return RedirectToAction("CountrySearchResult");
        }

        // Вывод результата
        public IActionResult CountrySearchResult()
        {
            var list = db.AllCountries.Where(c => c.CountryName == HelpElements.country.CountryName).ToList();
            if (list.Count != 0)
                return View(list);
            else
                return RedirectToAction("NothingFound");
        }
        //--------------------------------------------------------------

        //--------------------------------------------------------------
        // Контроллеры для поиска города
        public IActionResult CitySearch()
        {
            ViewBag.Title = "Поиск города по имени";
            return View();
        }

        // Передача города дейтсвию по выводу результата
        [HttpPost]
        public IActionResult CitySearch(Cities city)
        {
            HelpElements.city = city;
            return RedirectToAction("CountrySearchResult");
        }

        // Вывод результата
        public IActionResult CitySearchResult()
        {
            var list = db.AllCities.Where(c => c.CityName == HelpElements.city.CityName).ToList();
            if (list.Count != 0)
                return View(list);
            else
                return RedirectToAction("NothingFound");
        }
        //--------------------------------------------------------------

        //--------------------------------------------------------------
        // Контроллеры для поиска улицы
        public IActionResult RoadSearch()
        {
            ViewBag.Title = "Поиск улицы по имени";
            return View();
        }

        // Передача действий по поиску дороги
        [HttpPost]
        public IActionResult RoadSearch(RoadSystem road)
        {
            HelpElements.road = road;
            return RedirectToAction("RoadSearchResult");
        }

        // Вывод результат поиска
        public IActionResult RoadSearchResult()
        {
            var list = db.AllRoads.Where(c => c.StreetName == HelpElements.road.StreetName).ToList();
            if (list.Count != 0)
                return View(list);
            else
                return RedirectToAction("NothingFound");
        }
        //--------------------------------------------------------------

        //--------------------------------------------------------------
        // Контроллеры для поиска объекта
        public IActionResult ObjectSearch()
        {
            ViewBag.Title = "Поиск объекта по имени";
            return View();
        }

        // Передача действий по поиску объекта
        [HttpPost]
        public IActionResult ObjectSearch(UrbanObject uObject)
        {
            HelpElements.uObject = uObject;
            return RedirectToAction("ObjectSearchResult");
        }

        // вывод результата
        public IActionResult ObjectSearchResult()
        {
            var list = db.AllUrbanObjects.Where(c => c.ObjectName == HelpElements.uObject.ObjectName).ToList();
            if (list.Count != 0)
                return View(list);
            else
                return RedirectToAction("NothingFound");
        }
        //--------------------------------------------------------------

        //--------------------------------------------------------------
        // Контроллеры для поиска объекта по адресу
        public IActionResult ObjectAddresSearch()
        {
            ViewBag.Title = "Поиск объекта по адресу";
            return View();
        }

        // Поиск объекта по адрессу
        [HttpPost]
        public IActionResult ObjectAddresSearch(UrbanObject uObject)
        {
            HelpElements.uObject = uObject;
            return RedirectToAction("ObjectAddresSearchResult");
        }

        // Вывод результата
        public IActionResult ObjectAddresSearchResult()
        {
            var list = db.AllUrbanObjects.Where(c => c.Addres == HelpElements.uObject.Addres).ToList();
            if (list.Count != 0)
                return View(list);
            else
                return RedirectToAction("NothingFound");
        }
        //--------------------------------------------------------------

        // Переход на страницу с "Ничего не найдено"
        public IActionResult NothingFound()
        {
            ViewBag.Message = "Ничего не найдено";
            return View();
        }
    }
}
