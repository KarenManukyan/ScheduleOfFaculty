﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScheduleOfFaculty.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Resources;
using Kendo.Mvc.Infrastructure;

namespace ScheduleOfFaculty.Controllers
{
    public class LessonController : Controller
    {
        
        LessonStore store;
        public LessonController()
        {
            store = new LessonStore();
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
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Lesson> lessons)
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Lesson> lessons)
        {
            var results = new List<Lesson>();

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
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Lesson> lessons)
        {
            foreach (var lesson in lessons)
            {
                store.Destroy(lesson.id);
            }

            return Json(lessons.ToDataSourceResult(request));
        }

    }
}
