namespace BeerConf.Web.Application
{
	using System.Web.Mvc;

	public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
    }
}
