namespace BeerConf.Web.Application.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Account.Services;
    using Account.Services.Impl;
    using Brandy.Core;
    using Brandy.Web.Forms;
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
            NextEvent model = query.For<NextEvent>()
                .With(new Criteria.NextEvent(contextUserProvider.ContextUser(false)));

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
            return View(ToViewModel(eventRepository.Get(id)));
        }

        private EventDetails ToViewModel(Event @event)
        {
            return new EventDetails
                       {
                           Name = @event.Name,
                           Begin = @event.Begin,
                           End = @event.End,
                           Description = @event.Description,
                           Place = @event.Place,
                           PlacesCount = @event.MaxPlaces - @event.Participants.Count(),
                           Participants = GetEventParticipants(@event)
                       };
        }

        private IEnumerable<EventParticipant> GetEventParticipants(Event @event)
        {
            if (User.IsInRole("Admin"))
                return @event.Participants.Select(ToViewModel).ToArray();
            return Enumerable.Empty<EventParticipant>();
        }

        private static EventParticipant ToViewModel(User user)
        {
            return new EventParticipant
                       {
                           Login = user.Login,
                           Email = user.EMail,
                       };
        }

        [HttpPost]
        public ActionResult Participate(Participate form)
        {
            return Handle(form, RedirectToAction("Index", "Home"));
        }
    }
}
