namespace BeerConf.Web.Application.Events.Forms.Handlers
{
    using Account.Services;
    using Brandy.Core;
    using Brandy.Web.Forms;
    using Domain.Entities;

    public class ParticipateHandler : IFormHandler<Participate>
    {
        private readonly IContextUserProvider contextUserProvider;
        private readonly IRepository<Event> eventRepository;

        public ParticipateHandler(IRepository<Event> eventRepository, IContextUserProvider contextUserProvider)
        {
            this.eventRepository = eventRepository;
            this.contextUserProvider = contextUserProvider;
        }

        #region IFormHandler<Participate> Members

        public void Handle(Participate form)
        {
            Event @event = eventRepository.Get(form.EventId);
            @event.AddParticipant(contextUserProvider.ContextUser());
        }

        #endregion
    }
}
