namespace BeerConf.Web.Application.Events
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Account.Services;
    using Account.Services.Impl;
    using Brandy.Core;
    using Brandy.Web.Forms;
    using Criteria;
    using Domain.Entities;
    using Forms;
    using ViewModels;

    public class EventsController : FormControllerBase
    {
        private readonly IContextUserProvider contextUserProvider;
        private readonly IRepository<Event> eventRepository;
        private readonly IQueryBuilder query;

        public EventsController(IQueryBuilder query, IContextUserProvider contextUserProvider, IRepository<Event> eventRepository)
        {
            this.query = query;
            this.contextUserProvider = contextUserProvider;
            this.eventRepository = eventRepository;
        }

        [ChildActionOnly]
        public ActionResult NextEvent()
        {
            NextEventViewModel model = query.For<NextEventViewModel>()
                .With(new NextEvent(contextUserProvider.ContextUser(false)));

            return PartialView(model);
        }

        [CustomAuthorize(RoleType.Admin)]
        public ActionResult New()
        {
            return View(new NewEvent {Begin = DateTime.Now, End = DateTime.Now});
        }

        [HttpPost, CustomAuthorize(RoleType.Admin)]
        public ActionResult New(NewEvent form)
        {
            return Handle(form, RedirectToAction("New"));
        }

        public ActionResult Details(int id)
        {
            return View(ToEventDetailsViewModel(eventRepository.Get(id)));
        }

        private static EventDetailsViewModel ToEventDetailsViewModel(Event @event)
        {
            return new EventDetailsViewModel
                       {
                           Name = @event.Name,
                           Begin = @event.Begin,
                           End = @event.End,
                           Description = @event.Description,
                           Place = @event.Place,
                           PlacesCount = @event.MaxPlaces - @event.Participants.Count()
                       };
        }

        [HttpPost]
        public ActionResult Participate(Participate form)
        {
            return Handle(form, RedirectToAction("Index", "Home"));
        }
    }
}
