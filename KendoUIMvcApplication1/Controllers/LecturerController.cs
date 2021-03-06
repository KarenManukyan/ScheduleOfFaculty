﻿using System;
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

        LecturerStore store;
        public LecturerController() 
        {
            store = new LecturerStore();
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
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Lecturer> lecturers)
        {
            if (lecturers != null)
            {
                foreach (var lect in lecturers)
                {
                    store.Update(lect);
                }
            }

            return Json(lecturers.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Lecturer> lecturers)
        {
            var results = new List<Lecturer>();

            if (lecturers != null)
            {
                foreach (var lect in lecturers)
                {
                    store.Create(lect);

                    results.Add(lect);
                }
            }

            return Json(results.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Lecturer> lecturers)
        {
            foreach (var lect in lecturers)
            {
                store.Destroy(lect.Id);
            }

            return Json(lecturers.ToDataSourceResult(request));
        }


    }
}
