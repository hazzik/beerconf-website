namespace BeerConf.Web.Application.Events.Forms.Handlers
{
    using Brandy.Core;
    using Brandy.Web.Forms;
    using Domain.Entities;

    public class NewEventHandler : IFormHandler<NewEvent>
    {
        private readonly IRepository<Event> eventRepository;

        public NewEventHandler(IRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        #region IFormHandler<NewEvent> Members

        public void Handle(NewEvent form)
        {
            eventRepository.Add(new Event
                                    {
                                        Begin = form.Begin,
                                        End = form.End,
                                        Description = form.Description,
                                        Name = form.Name,
                                        Place = form.Place,
                                    });
        }

        #endregion
    }
}
