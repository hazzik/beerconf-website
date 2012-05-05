namespace BeerConf.Web.Application.Events
{
    using System;
    using System.Web.Mvc;

    using Brandy.Core;
    using Brandy.Security.Entities;
    using Brandy.Security.Web;
    using Brandy.Security.Web.Services;
    using Brandy.Security.Web.Services.Impl;
    using Brandy.Web.Forms;
    using Domain.Entities;
    using Forms;
    using OoMapper;
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

        [BrandyAuthorize(RoleType.Admin)]
        public ActionResult New()
        {
            return View(new NewEvent {Begin = DateTime.Now, End = DateTime.Now});
        }

        [HttpPost, BrandyAuthorize(RoleType.Admin)]
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
            return !User.IsInRole("Admin")
                       ? Mapper.Map<Event, EventDetails>(@event)
                       : Mapper.Map<Event, AdminEventDetails>(@event);
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
