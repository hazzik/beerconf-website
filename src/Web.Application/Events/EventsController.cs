namespace BeerConf.Web.Application.Events
{
	using System.Web.Mvc;

	public class EventsController : Controller
	{
		public ActionResult New()
		{
			return View(new NewEventForm());
		}
	}
}
