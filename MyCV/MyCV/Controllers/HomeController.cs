using MyCV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCV.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new PersonalInfoModel();
            return View(model);
        }

    }
}