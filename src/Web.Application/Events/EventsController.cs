namespace BeerConf.Web.Application.Events
{
    using System.Web.Mvc;
    using Brandy.Core;
    using Brandy.Web.Forms;
    using Criteria;
    using Forms;
    using ViewModels;

    public class EventsController : FormControllerBase
    {
        private readonly IQueryBuilder query;

        public EventsController(IQueryBuilder query)
        {
            this.query = query;
        }

        [ChildActionOnly]
        public ActionResult NextEvent()
        {
            NextEventViewModel model = query.For<NextEventViewModel>()
                .With(new NextEvent());

            return PartialView(model);
        }

        public ActionResult New()
        {
            return View(new NewEvent());
        }

        [HttpPost]
        public ActionResult New(NewEvent form)
        {
            return Handle(form, RedirectToAction("New"));
        }

        [HttpPost]
        public ActionResult Participate(Participate form)
        {
            return Handle(form, RedirectToAction("Index", "Home"));
        }
    }
}
