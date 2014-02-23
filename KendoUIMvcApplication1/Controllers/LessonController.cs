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
    public class LessonController : Controller
    {
        DbManager dbManager;
        public LessonController()
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
            var data = dbManager.GetLessons();
            return Json(data.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, LessonGrid lessonGrid)
        {
            if (lessonGrid != null && ModelState.IsValid)
            {
                    lesson les = new lesson();
                    les.id = lessonGrid.Id;
                    les.name = lessonGrid.Name;
                    les.time = lessonGrid.Time;
                    les.typeId = 3;
                    dbManager.Update(les);
            }

            return Json((new[]{lessonGrid}.ToDataSourceResult(request, ModelState)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,LessonGrid lessonGrid)
        {
            var results = new List<LessonGrid>();

            if (lessonGrid != null && ModelState.IsValid)
            {
                    lesson les=new lesson();
                    les.name = lessonGrid.Name;
                    les.time = lessonGrid.Time;
                    les.typeId = 1;
                    dbManager.CreateLesson(les);
                    results.Add(lessonGrid);
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,LessonGrid lessonGrid)
        {
            if (lessonGrid != null && ModelState.IsValid)
            {
                lesson les = new lesson();
                les.id = lessonGrid.Id;
                les.name = lessonGrid.Name;
                les.time = lessonGrid.Time;
                dbManager.DestroyLesson(les);
            }

            return Json(new[]{lessonGrid}.ToDataSourceResult(request, ModelState));
        }

    }
}
