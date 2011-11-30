namespace BeerConf.Infrastructure.NHibernate.Queries.Events
{
    using System;
    using System.Linq;
    using Brandy.NHibernate;
    using Domain.Entities;
    using Web.Application.Events.Criteria;
    using Web.Application.Events.ViewModels;
    using NextEvent = Web.Application.Events.ViewModels.NextEvent;

    public class NextEventQuery : NHibernateLinqQueryBase<NextEvent, Web.Application.Events.Criteria.NextEvent>
    {
        public NextEventQuery(ILinqProvider linqProvider) : base(linqProvider)
        {
        }

        public override NextEvent Ask(Web.Application.Events.Criteria.NextEvent criterion)
        {
            return Query<Event>()
                .Where(x => x.Begin >= DateTime.Today)
                .OrderBy(x => x.Begin)
                .Select(x => new NextEvent
                                 {
                                     Id = x.Id,
                                     Begin = x.Begin,
                                     Name = x.Name,
                                     IsParticipating = criterion.User != null && x.Participants.Contains(criterion.User),
                                     PlacesCount = x.MaxPlaces - x.Participants.Count()
                                 })
                .FirstOrDefault();
        }
    }
}
