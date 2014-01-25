using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Kendo.Mvc.UI;
using ScheduleOfFaculty.Models;
using ScheduleOfFaculty.Services;

namespace ScheduleOfFaculty.Controllers
{
    public class AccountController : Controller
    {
        private static string USER_NAME = "UserName";
        private static string PASSWORD = "Password";
        private static int TIME_FOR_COOKIE = 20;
        DbManager dbManager;

        public AccountController()
        {
            dbManager = new DbManager();
        }
        public ActionResult Index()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string userName = model.UserName;
                    string password = model.Password;
                    if (userName != null && password != null)
                    {

                        login log = dbManager.GetCurrentUserLogin(userName, password);
                        if (log != null)
                        {
                            lecturer user = dbManager.GetCurrentUser(log.lecturerId);
                            Session["Login"] = log;
                            Session["CurrentUser"] = user;
                            HttpCookie userNameCookie = Cookies.AddCookie(USER_NAME, userName, TIME_FOR_COOKIE);
                            HttpCookie passwordCookie = Cookies.AddCookie(PASSWORD, password, TIME_FOR_COOKIE);
                            this.ControllerContext.HttpContext.Response.Cookies.Add(userNameCookie);
                            this.ControllerContext.HttpContext.Response.Cookies.Add(passwordCookie);
                           
                        }

                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                }

            }
            return Json(new {});
        }

        //
        // GET: /Account/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Account/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Account/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Account/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Account/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Account/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Account/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
