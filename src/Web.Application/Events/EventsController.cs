namespace BeerConf.Web.Application.Events
{
    using System.Web.Mvc;
    using Brandy.Core;
    using Brandy.Web.Forms;
    using Domain.Entities;

    public class EventsController : FormControllerBase
    {
        private IQueryBuilder query;

        public EventsController(IQueryBuilder query)
        {
            this.query = query;
        }

        [ChildActionOnly]
        public ActionResult NextEvent()
        {
            var model = query.For<NextEventViewModel>()
                .With(new NextEvent());

            return PartialView(model);
        }

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
