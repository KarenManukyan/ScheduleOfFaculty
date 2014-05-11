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
        LecturerLessonStore store;
        public HomeController() 
        {
            store = new LecturerLessonStore();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(store.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, IEnumerable<LessonLecturerGrid> lessons)
        {
            if (lessons != null)
            {
                foreach (var less in lessons)
                {
                    store.Update(less);
                }
            }
            return Json(lessons.ToDataSourceResult(request));
        }


        public ActionResult Create([DataSourceRequest] DataSourceRequest request, IEnumerable<LessonLecturerGrid> lessons)
        {
            var results = new List<LessonLecturerGrid>();
            if (lessons != null)
            {
                foreach (var lesson in lessons)
                {
                    store.Create(lesson);
                    results.Add(lesson);
                }
            }
            return Json(results.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, IEnumerable<LessonLecturerGrid> lessons)
        {
            foreach (var lesson in lessons)
            {
                store.Destroy(lesson.Id);
            }
            return Json(lessons.ToDataSourceResult(request));
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
