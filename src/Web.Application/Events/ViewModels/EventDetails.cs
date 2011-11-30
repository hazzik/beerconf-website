namespace BeerConf.Web.Application.Events.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class EventDetails
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public int? PlacesCount { get; set; }
        public IEnumerable<EventParticipant> Participants { get; set; }
    }
}
