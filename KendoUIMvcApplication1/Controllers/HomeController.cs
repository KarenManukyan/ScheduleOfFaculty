using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using ScheduleOfFaculty.Models;
using System.Web.Script.Serialization;
using ScheduleOfFaculty.Services;

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
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        
        public FileContentResult GetDocument()
        {
            Report report=new Report();
            byte[] doc = report.GetDocument();
            string mimeType = "application/docx";
            Response.AppendHeader("Content-Disposition", "inline; filename=WordReport.docx");
            return File(doc, mimeType);
        }
    }
}
