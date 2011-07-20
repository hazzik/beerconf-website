namespace BeerConf.Web.Application.Events
{
    using Brandy.Core;
    using Brandy.Web.Forms;
    using Domain.Entities;

    public class NewEventFormHandler : IFormHandler<NewEventForm>
    {
        private readonly IRepository<Event> eventRepository;

        public NewEventFormHandler(IRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        #region IFormHandler<NewEventForm> Members

        public void Handle(NewEventForm form)
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
