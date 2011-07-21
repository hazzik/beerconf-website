namespace BeerConf.Web.Application.Events
{
    using System;

    public class NextEventViewModel
    {
        public int Id { get; set; }

        public DateTime Begin { get; set; }

        public string Name { get; set; }
    }
}