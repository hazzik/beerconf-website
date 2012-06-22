namespace BeerConf.Web.Application.Errors
{
    using System.Web.Mvc;

    public class ErrorsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
