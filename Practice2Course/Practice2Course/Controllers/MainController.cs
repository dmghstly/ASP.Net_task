using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practice2Course.Data;
using Practice2Course.Data.Models;
using Syncfusion.XlsIO;

namespace Practice2Course.Controllers
{
    public class MainController : Controller
    {
        public static FileName fileName = new FileName();

        // Вывод данных в файл Excel
        public void MakeExcel()
        {
            ExcelEngine excel = new ExcelEngine();
            IApplication app = excel.Excel;
            IWorkbook MainWB = app.Workbooks.Create(4);
            

            #region init
            IWorksheet CoWS = MainWB.Worksheets[0];
            CoWS.Name = "Страны";
            IWorksheet CiWS = MainWB.Worksheets[1];
            CiWS.Name = "Города";
            IWorksheet RWS = MainWB.Worksheets[2];
            RWS.Name = "Улицы";
            IWorksheet UOWS = MainWB.Worksheets[3];
            UOWS.Name = "Градостроительные объекты";
            #endregion

            #region styles
            IStyle headerStyle = MainWB.Styles.Add("HeaderStyle");
            headerStyle.BeginUpdate();
            headerStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            headerStyle.VerticalAlignment = ExcelVAlign.VAlignBottom;
            headerStyle.Font.Bold = true;
            headerStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
            headerStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
            headerStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
            headerStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
            headerStyle.EndUpdate();

            IStyle mainStyle = MainWB.Styles.Add("MainStyle");
            mainStyle.BeginUpdate();
            mainStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            mainStyle.VerticalAlignment = ExcelVAlign.VAlignBottom;
            mainStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
            mainStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
            mainStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
            mainStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
            mainStyle.EndUpdate();
            #endregion

            #region countries
            CoWS.Range[1, 1].Text = "Наименование";
            CoWS.Range[1, 2].Text = "Описание";
            var listCoWS = db.AllCountries.ToList();
            listCoWS.Sort(Countries.CompareByName);
            int i = 2;
            foreach(var el in listCoWS)
            {
                CoWS.Range[i, 1].Text = el.CountryName;
                CoWS.Range[i, 2].Text = el.Description;
                i++;
            }
            i--;
            CoWS.Range[1, 1, i--, 2].CellStyle = mainStyle;
            CoWS.UsedRange.AutofitColumns();
            CoWS.UsedRange.AutofitRows();
            CoWS.Range[1, 1, 1, 2].CellStyle = headerStyle;
            #endregion

            #region cities
            CiWS.Range[1, 1].Text = "Наименование";
            CiWS.Range[1, 2].Text = "Страна";
            CiWS.Range[1, 3].Text = "Описание";
            var listCiWS = db.AllCities.ToList();
            listCiWS.Sort(Cities.CompareByName);
            i = 2;
            foreach (var el in listCiWS)
            {
                CiWS.Range[i, 1].Text = el.CityName;
                CiWS.Range[i, 2].Text = db.AllCountries.Find(el.CountryId).CountryName;
                CiWS.Range[i, 3].Text = el.Description;
                i++;
            }
            i--;
            CiWS.Range[1, 1, i--, 3].CellStyle = mainStyle;
            CiWS.UsedRange.AutofitColumns();
            CiWS.UsedRange.AutofitRows();
            CiWS.Range[1, 1, 1, 3].CellStyle = headerStyle;
            #endregion

            #region roadsystem
            RWS.Range[1, 1].Text = "Наименование";
            RWS.Range[1, 2].Text = "Город";
            RWS.Range[1, 3].Text = "Описание";
            var listRWS = db.AllRoads.ToList();
            listRWS.Sort(RoadSystem.CompareByName);
            i = 2;
            foreach (var el in listRWS)
            {
                if (el.StreetName != "-")
                {
                    RWS.Range[i, 1].Text = HelpElements.StreetDictionary[el.CityId][el.StreetId];
                    RWS.Range[i, 2].Text = HelpElements.CitiesDictionary[el.CityId];
                    RWS.Range[i, 3].Text = el.Description;
                    i++;
                }
            }
            i--;
            RWS.Range[1, 1, i--, 3].CellStyle = mainStyle;
            RWS.UsedRange.AutofitColumns();
            RWS.UsedRange.AutofitRows();
            RWS.Range[1, 1, 1, 3].CellStyle = headerStyle;
            #endregion

            #region objects
            UOWS.Range[1, 1].Text = "Наименование";
            UOWS.Range[1, 2].Text = "Тип";
            UOWS.Range[1, 3].Text = "Адрес";
            UOWS.Range[1, 4].Text = "Город";
            UOWS.Range[1, 5].Text = "Описание";
            var listUOWS = db.AllUrbanObjects.ToList();
            listUOWS.Sort(UrbanObject.CompareByName);
            i = 2;
            foreach (var el in listUOWS)
            {
                UOWS.Range[i, 1].Text = el.ObjectName;
                UOWS.Range[i, 2].Text = HelpElements.UrbanTypesDictionary[el.TypeId];
                UOWS.Range[i, 3].Text = el.Addres;
                UOWS.Range[i, 4].Text = HelpElements.CitiesDictionary[db.AllRoads.Find(el.StreetId).CityId];
                UOWS.Range[i, 5].Text = el.Description;
                i++;
            }
            i--;
            UOWS.Range[1, 1, i--, 5].CellStyle = mainStyle;
            UOWS.UsedRange.AutofitColumns();
            UOWS.UsedRange.AutofitRows();
            UOWS.Range[1, 1, 1, 5].CellStyle = headerStyle;
            #endregion

            FileStream output = new FileStream("C:/Practice2/" + fileName.Name + ".xlsx", FileMode.Create);
            MainWB.SaveAs(output);
            output.Close();
        }


        public List<RoadSystem> JoinRoadList(List<RoadSystem> list, List<RoadSystem> check)
        {
            foreach (var el in check)
                list.Add(el);
            return list;
        }


        public List<UrbanObject> JoinUrbanList(List<UrbanObject> list, List<UrbanObject> check)
        {
            foreach (var el in check)
                list.Add(el);
            return list;
        }

        public UPISContext db;

        public MainController(UPISContext context)
        {
            db = context;
        }

        // Вывод шдавной страницы
        public IActionResult CountryPage()
        {
            HelpElements.MakeAbbsDictionary();
            HelpElements.MakeCountriesDictionary(db);
            HelpElements.MakeCitiesDictionary(db);
            HelpElements.MakeTypesDictionary(db);
            HelpElements.MakeStreetDictionary(db);          
            ViewBag.Title = "Список стран";
            var list = db.AllCountries.ToArray();
            Array.Sort(list, Countries.CompareByName);
            return View(list);
        }

        // Страница о сайте
        public IActionResult AboutSite()
        {
            ViewBag.Title = "О сайте";
            return View();
        }

        // Страница с вводом имени файла
        public IActionResult MakeFileName()
        {
            ViewBag.Title = "Имя файла";
            return View();
        }

        // Переход к действию по созданию файла
        [HttpPost]
        public IActionResult MakeFileName(FileName file)
        {
            fileName.Name = file.Name;
            return RedirectToAction("CompleteReport");
        }

        // Создание и сохранение файла Excel
        public IActionResult CompleteReport()
        {
            MakeExcel();
            ViewBag.Title = "Отчёт";
            ViewBag.Message = "Данные успешно выгружены в файл: " + fileName.Name + ".xslx";
            return View();
        }

        // Страница с гордами
        public IActionResult CityPage()
        {
            HelpElements.MakeCitiesDictionary(db);
            ViewBag.Title = "Список городов";
            var list = db.AllCities.ToList();
            list.Sort(Cities.CompareByName);
            return View(list);
        }
        
        // Вывод всех городов в конкретной стране
        [HttpGet]
        public IActionResult SelectedCities(int? id)
        {
            var list = db.AllCities.ToList();
            List<Cities> SelectedList = new List<Cities>();
            foreach (var el in list)
            {
                if (id == el.CountryId)
                    SelectedList.Add(el);
            }
            ViewBag.Title = "Список городов";
            ViewBag.Message = "Список городов в стране " + HelpElements.CountriesDictionary[(int)id];
            SelectedList.Sort(Cities.CompareByName);
            return View(SelectedList);
        }

        // Вывод улиц в конкретном городе
        [HttpGet]
        public IActionResult SelectedStreets(int? id)
        {
            HelpElements.HelpCityID = Convert.ToInt32(id);
            var list = db.AllRoads.Where(c => c.CityId == id && c.StreetName != "-").ToList();
            list.Sort(RoadSystem.CompareByName);
            ViewBag.Title = "Список улиц";
            ViewBag.Message = "Список улиц в " + HelpElements.CitiesDictionary[(int)id];
            return View(list);
        }

        // Вывод улиц по фильтрам
        [HttpPost]
        public IActionResult SelectedStreets(RoadFilters roadFilters)
        {
            var list = db.AllRoads.Where(c => c.CityId == HelpElements.HelpCityID && c.StreetName != "-").ToList();
            List<RoadSystem> UlList = new List<RoadSystem>();
            List<RoadSystem> PereUlList = new List<RoadSystem>();
            List<RoadSystem> ProsList = new List<RoadSystem>();
            List<RoadSystem> ShosList = new List<RoadSystem>();
            List<RoadSystem> ProList = new List<RoadSystem>();
            List<RoadSystem> BoulList = new List<RoadSystem>();
            List<RoadSystem> DorList = new List<RoadSystem>();
            List<RoadSystem> AveList = new List<RoadSystem>();
            List<RoadSystem> PlList = new List<RoadSystem>();
            if (roadFilters.All)
            {
                list.Sort(RoadSystem.CompareByName);
                return View(list);
            }
            else
            {
                if (roadFilters.UlFilter)
                    UlList = list.Where(c => c.TypeId == 7).ToList();
                if (roadFilters.PereUlFilter)
                    PereUlList = list.Where(c => c.TypeId == 8).ToList();
                if (roadFilters.ProsFilter)
                    ProsList = list.Where(c => c.TypeId == 9).ToList();
                if (roadFilters.ShosFilter)
                    ShosList = list.Where(c => c.TypeId == 10).ToList();
                if (roadFilters.ProezdFilter)
                    ProList = list.Where(c => c.TypeId == 11).ToList();
                if (roadFilters.BoulFilter)
                    BoulList = list.Where(c => c.TypeId == 12).ToList();
                if (roadFilters.DorFilter)
                    DorList = list.Where(c => c.TypeId == 13).ToList();
                if (roadFilters.AveFilter)
                    AveList = list.Where(c => c.TypeId == 15).ToList();
                if (roadFilters.PlFilter)
                    PlList = list.Where(c => c.TypeId == 16).ToList();
                List<RoadSystem> FinalList = new List<RoadSystem>();
                FinalList = JoinRoadList(FinalList, UlList);
                FinalList = JoinRoadList(FinalList, PereUlList);
                FinalList = JoinRoadList(FinalList, ProsList);
                FinalList = JoinRoadList(FinalList, ShosList);
                FinalList = JoinRoadList(FinalList, ProList);
                FinalList = JoinRoadList(FinalList, BoulList);
                FinalList = JoinRoadList(FinalList, DorList);
                FinalList = JoinRoadList(FinalList, AveList);
                FinalList = JoinRoadList(FinalList, PlList);
                FinalList.Sort(RoadSystem.CompareByName);
                return View(FinalList);
            }
        }

        // Вывод объектов в конкретном городе
        [HttpGet]
        public IActionResult SelectedObjectsbyCity(int? id)
        {
            HelpElements.HelpCityID = Convert.ToInt32(id);
            HelpElements.HelpStreetID = Convert.ToInt32(id);
            var list = db.AllUrbanObjects.ToList();
            var SelectedList = db.AllUrbanObjects.ToList();
            SelectedList.Clear();
            foreach (var el in list)
            {
                if (HelpElements.StreetDictionary[Convert.ToInt32(id)].ContainsKey(el.StreetId))
                    SelectedList.Add(el);
            }
            ViewBag.Title = "Список градостроительных объектов";
            ViewBag.Message = "Список объектов в " + HelpElements.CitiesDictionary[(int)id];
            SelectedList.Sort(UrbanObject.CompareByName);
            return View(SelectedList);
        }

        // Вывод объектов по фильтрам
        [HttpPost]
        public IActionResult SelectedObjectsbyCity(UrbanFilters urbanFilters)
        {
            var list = db.AllUrbanObjects.ToList();
            var SelectedList = db.AllUrbanObjects.ToList(); ;
            SelectedList.Clear();
            foreach (var el in list)
            {
                if (HelpElements.StreetDictionary[Convert.ToInt32(HelpElements.HelpStreetID)].ContainsKey(el.StreetId))
                    SelectedList.Add(el);
            }
            if (urbanFilters.All)
            {
                SelectedList.Sort(UrbanObject.CompareByName);
                return View(SelectedList);
            }
            else
            {
                List<UrbanObject> IngList = new List<UrbanObject>();
                List<UrbanObject> TranspList = new List<UrbanObject>();
                List<UrbanObject> SocList = new List<UrbanObject>();
                List<UrbanObject> NatList = new List<UrbanObject>();
                List<UrbanObject> ProdList = new List<UrbanObject>();
                List<UrbanObject> LivList = new List<UrbanObject>();
                List<UrbanObject> CultList = new List<UrbanObject>();
                List<UrbanObject> CommList = new List<UrbanObject>();
                if (urbanFilters.IngFilter)
                    IngList = SelectedList.Where(c => c.TypeId == 7).ToList();
                if (urbanFilters.TranspFilter)
                    TranspList = SelectedList.Where(c => c.TypeId == 8).ToList();
                if (urbanFilters.SocFilter)
                    SocList = SelectedList.Where(c => c.TypeId == 9).ToList();
                if (urbanFilters.NatFilter)
                    NatList = SelectedList.Where(c => c.TypeId == 10).ToList();
                if (urbanFilters.ProdFilter)
                    ProdList = SelectedList.Where(c => c.TypeId == 11).ToList();
                if (urbanFilters.LivFilter)
                    LivList = SelectedList.Where(c => c.TypeId == 12).ToList();
                if (urbanFilters.CultFilter)
                    CultList = SelectedList.Where(c => c.TypeId == 13).ToList();
                if (urbanFilters.CommFilter)
                    CommList = SelectedList.Where(c => c.TypeId == 14).ToList();
                List<UrbanObject> FinalList = new List<UrbanObject>();
                FinalList = JoinUrbanList(FinalList, IngList);
                FinalList = JoinUrbanList(FinalList, TranspList);
                FinalList = JoinUrbanList(FinalList, SocList);
                FinalList = JoinUrbanList(FinalList, NatList);
                FinalList = JoinUrbanList(FinalList, ProdList);
                FinalList = JoinUrbanList(FinalList, LivList);
                FinalList = JoinUrbanList(FinalList, CultList);
                FinalList = JoinUrbanList(FinalList, CommList);
                FinalList.Sort(UrbanObject.CompareByName);
                return View(FinalList);
            }
        }

        // Вывод объектов на конкретной улице
        [HttpGet]
        public IActionResult SelectedObjectsbyStreet(int? id)
        {
            var list = db.AllUrbanObjects.Where(c => c.StreetId == Convert.ToInt32(id)).ToList();
            var item = db.AllRoads.Find(id);
            HelpElements.HelpCityID = item.CityId;
            HelpElements.HelpStreetID = Convert.ToInt32(id);
            ViewBag.Title = "Список градостроительных объектов";
            ViewBag.Message = "Список объектов в " + HelpElements.CitiesDictionary[(int)id];
            list.Sort(UrbanObject.CompareByName);
            return View(list);
        }

        // Вывод объектов по фильтрам
        [HttpPost]
        public IActionResult SelectedObjectsbyStreet(UrbanFilters urbanFilters)
        {
            var list = db.AllUrbanObjects.Where(c => c.StreetId == HelpElements.HelpStreetID).ToList();
            List<UrbanObject> IngList = new List<UrbanObject>();
            List<UrbanObject> TranspList = new List<UrbanObject>();
            List<UrbanObject> SocList = new List<UrbanObject>();
            List<UrbanObject> NatList = new List<UrbanObject>();
            List<UrbanObject> ProdList = new List<UrbanObject>();
            List<UrbanObject> LivList = new List<UrbanObject>();
            List<UrbanObject> CultList = new List<UrbanObject>();
            List<UrbanObject> CommList = new List<UrbanObject>();
            if (urbanFilters.All)
            {
                list.Sort(UrbanObject.CompareByName);
                return View(list);
            }
            else
            {
                if (urbanFilters.IngFilter)
                    IngList = list.Where(c => c.TypeId == 7).ToList();
                if (urbanFilters.TranspFilter)
                    TranspList = list.Where(c => c.TypeId == 8).ToList();
                if (urbanFilters.SocFilter)
                    SocList = list.Where(c => c.TypeId == 9).ToList();
                if (urbanFilters.NatFilter)
                    NatList = list.Where(c => c.TypeId == 10).ToList();
                if (urbanFilters.ProdFilter)
                    ProdList = list.Where(c => c.TypeId == 11).ToList();
                if (urbanFilters.LivFilter)
                    LivList = list.Where(c => c.TypeId == 12).ToList();
                if (urbanFilters.CultFilter)
                    CultList = list.Where(c => c.TypeId == 13).ToList();
                if (urbanFilters.CommFilter)
                    CommList = list.Where(c => c.TypeId == 14).ToList();
                List<UrbanObject> SelectedList = new List<UrbanObject>();
                SelectedList = JoinUrbanList(SelectedList, IngList);
                SelectedList = JoinUrbanList(SelectedList, TranspList);
                SelectedList = JoinUrbanList(SelectedList, SocList);
                SelectedList = JoinUrbanList(SelectedList, NatList);
                SelectedList = JoinUrbanList(SelectedList, ProdList);
                SelectedList = JoinUrbanList(SelectedList, LivList);
                SelectedList = JoinUrbanList(SelectedList, CultList);
                SelectedList = JoinUrbanList(SelectedList, CommList);
                SelectedList.Sort(UrbanObject.CompareByName);
                return View(SelectedList);
            }
        }
    }
}
