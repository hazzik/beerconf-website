namespace BeerConf.Web.Application.Events.ViewModels
{
    using System.Collections.Generic;

    public class AdminEventDetails : EventDetails
    {
        public IEnumerable<EventParticipant> Participants { get; set; }
    }
}