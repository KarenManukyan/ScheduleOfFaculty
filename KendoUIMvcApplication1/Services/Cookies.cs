using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScheduleOfFaculty.Services
{
    public  static class Cookies
    {
        public static HttpCookie AddCookie(string name,string value,int time) {
            HttpCookie cookie = new HttpCookie(name.ToString());
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddMinutes(time);
            return cookie;
        }
    }
}