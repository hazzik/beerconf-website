namespace BeerConf.Web.Application.Events.Forms
{
    using System;
    using Brandy.Web.Forms;

    public class NewEvent : IForm
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string Place { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
