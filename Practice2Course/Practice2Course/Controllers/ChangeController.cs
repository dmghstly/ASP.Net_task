using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practice2Course.Data;
using Practice2Course.Data.Models;

namespace Practice2Course.Controllers
{
    public class ChangeController : Controller
    {
        public UPISContext db;
        public ChangeController(UPISContext context)
        {
            db = context;
        }
        //--------------------------------------------------------------
        // Контроллеры для изменения страны
        [HttpGet]
        public IActionResult ChangeCountry(int? id)
        {
            var country = db.AllCountries.Find(id);
            HelpElements.country = country;
            return View(country);
        }

        // Вывод информаци на страницу с изменениями
        [HttpPost]
        public IActionResult ChangeCountry(Countries country)
        {
            if (ModelState.IsValid)
            {
                var CurrCountry = db.AllCountries.Where(c => c.CountryId == HelpElements.country.CountryId).First();
                CurrCountry.CountryName = country.CountryName;
                CurrCountry.ImgUrl = country.ImgUrl;
                CurrCountry.MapUrl = country.MapUrl;
                CurrCountry.Description = country.Description;
                db.SaveChanges();
                HelpElements.MakeCountriesDictionary(db);
                HelpElements.MakeCitiesDictionary(db);
                HelpElements.MakeStreetDictionary(db);
                return RedirectToAction("CompleteChangeCountry");
            }
            return View(country);
        }

        // Сохранение изменений
        public IActionResult CompleteChangeCountry()
        {
            ViewBag.Message = "Данные успешно изменены";
            return View();
        }
        //--------------------------------------------------------------

        //--------------------------------------------------------------
        // Контроллеры для изменения города
        [HttpGet]
        public IActionResult ChangeCity(int? id)
        {
            var city = db.AllCities.Find(id);
            HelpElements.city = city;
            return View(city);
        }

        // Вывод информации о городе на страницу изменения
        [HttpPost]
        public IActionResult ChangeCity(Cities city)
        {
            if (ModelState.IsValid)
            {
                var CurrCity = db.AllCities.Where(c => c.CityId == HelpElements.city.CityId).First();
                CurrCity.CityName = city.CityName;
                CurrCity.ImgUrl = city.ImgUrl;
                CurrCity.MapUrl = city.MapUrl;
                CurrCity.Description = city.Description;
                db.SaveChanges();
                HelpElements.MakeCountriesDictionary(db);
                HelpElements.MakeCitiesDictionary(db);
                HelpElements.MakeStreetDictionary(db);
                return RedirectToAction("CompleteChangeCity");
            }
            return View(city);
        }

        // Сохранение изменений
        public IActionResult CompleteChangeCity()
        {
            ViewBag.Message = "Данные успешно изменены";
            return View();
        }
        //--------------------------------------------------------------

        //--------------------------------------------------------------
        // Контроллеры для изменения улицы
        [HttpGet]
        public IActionResult ChangeRoad(int? id)
        {
            var road = db.AllRoads.Find(id);
            HelpElements.road = road;
            return View(road);
        }
        [HttpPost]

        // Вывод информации о дороге
        public IActionResult ChangeRoad(RoadSystem road)
        {
            if (ModelState.IsValid)
            {
                var CurrRoad = db.AllRoads.Where(c => c.StreetId == HelpElements.road.StreetId).First();
                CurrRoad.StreetName = road.StreetName;
                CurrRoad.ImgUrl = road.ImgUrl;
                CurrRoad.MapUrl = road.MapUrl;
                CurrRoad.Description = road.Description;
                db.SaveChanges();
                HelpElements.MakeCountriesDictionary(db);
                HelpElements.MakeCitiesDictionary(db);
                HelpElements.MakeStreetDictionary(db);
                return RedirectToAction("CompleteChangeCity");
            }
            return View(road);
        }

        // Сохранение изменений
        public IActionResult CompleteChangeRoad()
        {
            ViewBag.Message = "Данные успешно изменены";
            return View();
        }
        //--------------------------------------------------------------

        //--------------------------------------------------------------
        // Контроллеры для изменения объекта
        [HttpGet]
        public IActionResult ChangeObject(int? id)
        {
            var uObject = db.AllUrbanObjects.Find(id);
            HelpElements.uObject = uObject;
            HelpElements.HelpCityID = db.AllRoads.Find(uObject.StreetId).CityId;
            return View(uObject);
        }

        // Вывод информации об объекте
        [HttpPost]
        public IActionResult ChangeObject(UrbanObject uObject)
        {
            if (ModelState.IsValid)
            {
                var CurrObject = db.AllUrbanObjects.Where(c => c.ObjectId == HelpElements.uObject.ObjectId).First();
                CurrObject.ObjectName = uObject.ObjectName;
                CurrObject.ImgUrl = uObject.ImgUrl;
                CurrObject.MapUrl = uObject.MapUrl;
                CurrObject.Description = uObject.Description;
                CurrObject.Number = uObject.Number;
                CurrObject.Addres = HelpElements.StreetDictionary[HelpElements.HelpCityID][HelpElements.uObject.StreetId] + " " + uObject.Number;
                db.SaveChanges();
                HelpElements.MakeCountriesDictionary(db);
                HelpElements.MakeCitiesDictionary(db);
                HelpElements.MakeStreetDictionary(db);
                return RedirectToAction("CompleteChangeObject");
            }
            return View(uObject);
        }

        // Сохранение изменений
        public IActionResult CompleteChangeObject()
        {
            ViewBag.Message = "Данные успешно изменены";
            return View();
        }
        //--------------------------------------------------------------
    }
}
