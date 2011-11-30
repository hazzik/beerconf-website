namespace BeerConf.Web.Application.Events.ViewModels
{
    using System;

    public class NextEvent
    {
        public int Id { get; set; }

        public DateTime Begin { get; set; }

        public string Name { get; set; }

        public bool IsParticipating { get; set; }

        public int? PlacesCount { get; set; }
    }
}