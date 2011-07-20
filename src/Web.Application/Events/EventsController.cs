namespace BeerConf.Web.Application.Events
{
    using System.Web.Mvc;
    using Brandy.Web.Forms;

    public class EventsController : FormControllerBase
    {
        public ActionResult New()
        {
            return View(new NewEventForm());
        }

        [HttpPost]
        public ActionResult New(NewEventForm form)
        {
            return Handle(form, RedirectToAction("New"));
        }
    }
}
