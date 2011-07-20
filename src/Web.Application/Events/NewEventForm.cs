namespace BeerConf.Web.Application.Events
{
	using System;
	using Forms;

	public class NewEventForm : IForm
	{
		public DateTime Begin { get; set; }
		public DateTime End { get; set; }
		public string Place { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
