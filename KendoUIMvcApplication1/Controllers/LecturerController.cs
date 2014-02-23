using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using ScheduleOfFaculty.Models;
using Kendo.Mvc.Extensions;
namespace ScheduleOfFaculty.Controllers
{
    public class LecturerController : Controller
    {
        DbManager dbManager;
        public LecturerController()
        {
            dbManager = new DbManager();
        }

        public ActionResult Index()
        {
            ViewBag.data = dbManager.GetLessons();
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = dbManager.GetLecturers();
            return Json(data.ToDataSourceResult(request));
        }

        
    }
}
