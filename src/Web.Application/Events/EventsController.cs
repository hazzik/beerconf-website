namespace BeerConf.Web.Application.Events
{
    using System;
    using System.Web.Mvc;
    using Account.Services;
    using Brandy.Core;
    using Brandy.Web.Forms;
    using Criteria;
    using Forms;
    using ViewModels;

    public class EventsController : FormControllerBase
    {
        private readonly IQueryBuilder query;
        private readonly IContextUserProvider contextUserProvider;

        public EventsController(IQueryBuilder query, IContextUserProvider contextUserProvider)
        {
            this.query = query;
            this.contextUserProvider = contextUserProvider;
        }

        [ChildActionOnly]
        public ActionResult NextEvent()
        {
            NextEventViewModel model = query.For<NextEventViewModel>()
                .With(new NextEvent(contextUserProvider.ContextUser(false)));

            return PartialView(model);
        }

        public ActionResult New()
        {
            return View(new NewEvent {Begin = DateTime.Now, End = DateTime.Now});
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
