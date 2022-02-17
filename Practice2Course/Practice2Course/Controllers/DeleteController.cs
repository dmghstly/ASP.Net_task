using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practice2Course.Data;
using Practice2Course.Data.Models;

namespace Practice2Course.Controllers
{
    public class DeleteController : Controller
    {
        public UPISContext db;
        public DeleteController(UPISContext context)
        {
            db = context;
        }
        //--------------------------------------------------------------
        // Контроллеры для удаления страны
        [HttpGet]
        public IActionResult DeleteCountry(int? id)
        {
            var country = db.AllCountries.Find(id);
            HelpElements.country = country;
            return View(country);
        }
        [HttpPost]
        public IActionResult DeleteCountry(Countries country)
        {
            db.AllCountries.Remove(HelpElements.country);
            db.SaveChanges();
            HelpElements.MakeCountriesDictionary(db);
            HelpElements.MakeCitiesDictionary(db);
            return RedirectToAction("CompleteDeleteCountry");
        }
        public IActionResult CompleteDeleteCountry()
        {
            ViewBag.Message = "Страна успешно удалена";
            return View();
        }
        //--------------------------------------------------------------

        //--------------------------------------------------------------
        // Контроллеры для удаления города
        [HttpGet]
        public IActionResult DeleteCity(int? id)
        {
            var city = db.AllCities.Find(id);
            HelpElements.city = city;
            return View(city);
        }
        [HttpPost]
        public IActionResult DeleteCity(Cities city)
        {
            db.AllCities.Remove(HelpElements.city);
            db.SaveChanges();
            HelpElements.MakeCountriesDictionary(db);
            HelpElements.MakeCitiesDictionary(db);
            return RedirectToAction("CompleteDeleteCity");
        }
        public IActionResult CompleteDeleteCity()
        {
            ViewBag.Message = "Город успешно удален";
            return View();
        }
        //--------------------------------------------------------------

        //--------------------------------------------------------------
        // Контроллеры для удаления улицы
        [HttpGet]
        public IActionResult DeleteRoad(int? id)
        {
            var road = db.AllRoads.Find(id);
            HelpElements.road = road;
            return View(road);
        }
        [HttpPost]
        public IActionResult DeleteRoad(RoadSystem road)
        {
            db.AllRoads.Remove(HelpElements.road);
            db.SaveChanges();
            HelpElements.MakeCountriesDictionary(db);
            HelpElements.MakeCitiesDictionary(db);
            HelpElements.MakeStreetDictionary(db);
            return RedirectToAction("CompleteDeleteRoad");
        }
        public IActionResult CompleteDeleteRoad()
        {
            ViewBag.Message = "Улица успешно удалена";
            return View();
        }
        //--------------------------------------------------------------

        //--------------------------------------------------------------
        // Контроллеры для удаления объекта
        [HttpGet]
        public IActionResult DeleteObject(int? id)
        {
            var uObject = db.AllUrbanObjects.Find(id);
            HelpElements.uObject = uObject;
            HelpElements.HelpCityID = db.AllRoads.Find(uObject.StreetId).CityId;
            return View(uObject);
        }
        [HttpPost]
        public IActionResult DeleteObject(UrbanObject uObject)
        {
            db.AllUrbanObjects.Remove(HelpElements.uObject);
            db.SaveChanges();
            HelpElements.MakeCountriesDictionary(db);
            HelpElements.MakeCitiesDictionary(db);
            HelpElements.MakeStreetDictionary(db);
            return RedirectToAction("CompleteDeleteObject");
        }
        public IActionResult CompleteDeleteObject()
        {
            ViewBag.Message = "Объект успешно удален";
            return View();
        }
        //--------------------------------------------------------------
    }
}
