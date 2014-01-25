using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using ScheduleOfFaculty.Models;
using System.Web.Script.Serialization;

namespace ScheduleOfFaculty.Controllers
{
    public class HomeController : Controller
    {

        DbManager dbManager;
        public HomeController()
        {
            dbManager = new DbManager();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LessonGrid([DataSourceRequest] DataSourceRequest request)
        {
            var data = dbManager.GetLessons();
            return Json(data.ToDataSourceResult(request));
        }

        public ActionResult LecturerGrid(int employeeID, [DataSourceRequest] DataSourceRequest request)
        {
            var data = dbManager.GetLecturer(employeeID);
            return Json(data.ToDataSourceResult(request),JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = dbManager.GetLessons();
            var serializer = new JavaScriptSerializer();
            var result = new ContentResult();
            serializer.MaxJsonLength = Int32.MaxValue; // Whatever max length you want here
            result.Content = serializer.Serialize(data.ToDataSourceResult(request));
            result.ContentType = "application/json";
            return result;
        }
    }
}
