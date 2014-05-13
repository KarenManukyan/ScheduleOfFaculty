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
    public class LessonTypeController : Controller
    {
        LessonTypeStore store;
        public LessonTypeController()
        {
            store = new LessonTypeStore();
        }

        public ActionResult Index()
        {
            GetLessons();
            GetTypes();
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(store.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<LessonTypeGrid> lessons)
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


        public ActionResult Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<LessonTypeGrid> lessons)
        {
            var results = new List<LessonTypeGrid>();
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
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<LessonTypeGrid> lessons)
        {
            foreach (var lesson in lessons)
            {
                store.Destroy(lesson.Id);
            }
            return Json(lessons.ToDataSourceResult(request));
        }

        private void GetLessons()
        {
            var data = store.GetLessons();
            ViewData["lesson"] = data;
            ViewData["defaultLesson"] = data.First();
        }

        private void GetTypes()
        {
            var data = store.GetTypes();
            ViewData["lessonType"] = data;
            ViewData["defaultLessonType"] = data.First();
        }
    }
}
