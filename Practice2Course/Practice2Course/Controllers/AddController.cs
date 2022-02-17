using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practice2Course.Data;
using Practice2Course.Data.Models;

namespace Practice2Course.Controllers
{
    public class AddController : Controller
    {
        public UPISContext db;
        public AddController(UPISContext context)
        {
            db = context;
        }
        //--------------------------------------------------------------
        // Контроллеры для добавления страны
        public IActionResult AddCountry()
        {
            ViewBag.Title = "Добавление страны";
            return View();
        }

        [HttpPost]
        public IActionResult AddCountry(Countries country)
        {
            if (ModelState.IsValid)
            {
                db.AllCountries.Add(country);
                db.SaveChanges();
                HelpElements.MakeCountriesDictionary(db);
                return RedirectToAction("CompleteAddCountry");
            }

            return View(country);
        }

        public IActionResult CompleteAddCountry()
        {
            ViewBag.Message = "Страна успешно добавлена";
            return View();
        }
        //--------------------------------------------------------------

        //--------------------------------------------------------------
        // Контроллеры для добавления города
        public IActionResult AddCity()
        {
            ViewBag.Title = "Добавление города";
            return View();
        }

        [HttpPost]
        public IActionResult AddCity(Cities city)
        {
            if (ModelState.IsValid)
            {
                db.AllCities.Add(city);
                db.SaveChanges();
                HelpElements.MakeCitiesDictionary(db);
                return RedirectToAction("CompleteAddCity");
            }

            return View(city);
        }

        public IActionResult CompleteAddCity()
        {
            var HelpCity = db.AllCities.OrderByDescending(x => x.CityId).Take(1).ToList();
            RoadSystem HelpRoad = new RoadSystem { StreetName = "-", CityId = HelpCity.ElementAt(0).CityId, TypeId = 7 };
            db.AllRoads.Add(HelpRoad);
            db.SaveChanges();
            HelpElements.MakeStreetDictionary(db);           
            ViewBag.Message = "Город успешно добавлен";
            return View();
        }
        //--------------------------------------------------------------

        //--------------------------------------------------------------
        // Контроллеры для добавления объекта
        public IActionResult AddObjectChooseCity()
        {
            ViewBag.Title = "Выбор города";
            return View();
        }

        [HttpPost]
        public IActionResult AddObjectChooseCity(Cities city)
        {
            HelpElements.HelpCityID = city.CityId;
            return RedirectToAction("AddObject");
        }

        public IActionResult AddObject()
        {
            ViewBag.Title = "Добавление градостроительного объекта";
            ViewBag.Message = "Добавление объекта в " + HelpElements.CitiesDictionary[HelpElements.HelpCityID];
            return View();
        }

        [HttpPost]
        public IActionResult AddObject(UrbanObject urbanObject)
        {
            if (ModelState.IsValid)
            {
                urbanObject.Addres = HelpElements.StreetDictionary[HelpElements.HelpCityID][urbanObject.StreetId] + " " + urbanObject.Number;
                db.AllUrbanObjects.Add(urbanObject);
                db.SaveChanges();
                return RedirectToAction("CompleteAddObject");
            }

            return View(urbanObject);
        }

        public IActionResult CompleteAddObject()
        {
            ViewBag.Message = "Градостроительный объект успешно добавлен";
            return View();
        }
        //--------------------------------------------------------------

        //--------------------------------------------------------------
        // Контроллеры для добавления улиц
        public IActionResult AddRoad()
        {
            ViewBag.Title = "Добавление элемента дорожной системы";
            return View();
        }

        [HttpPost]
        public IActionResult AddRoad(RoadSystem road)
        {
            if (ModelState.IsValid)
            {
                db.AllRoads.Add(road);
                db.SaveChanges();
                HelpElements.MakeStreetDictionary(db);
                return RedirectToAction("CompleteAddRoad");
            }

            return View(road);
        }

        public IActionResult CompleteAddRoad()
        {
            ViewBag.Message = "Элемент дорожной системы успешно добавлен";
            return View();
        }
        //--------------------------------------------------------------
    }
}
