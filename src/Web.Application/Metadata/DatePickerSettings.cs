namespace BeerConf.Web.Application.Metadata
{
	using System;
	using MvcExtensions;
	
	public class DatePickerSettings : IModelMetadataAdditionalSetting
	{
		public DateTime? MinDate { get; set; }
		public DateTime? MaxDate { get; set; }

		public object ToHtmlAttributes()
		{
			return new
			       	{
			       		role = "datepicker",
			       		data_min_date = MinDate,
			       		data_max_date = MaxDate,
			       	};
		}
	}
}
