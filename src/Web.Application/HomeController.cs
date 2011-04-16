using System;
using System.Web.Mvc;

namespace Web.Application
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new EmptyResult();
        }
    }
}
