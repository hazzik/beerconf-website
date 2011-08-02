namespace BeerConf.Web.Application.Events.ViewModels.Metadata
{
    using MvcExtensions;

    public class EventDetailsViewModelMetadata : ModelMetadataConfiguration<EventDetailsViewModel>
    {
        public EventDetailsViewModelMetadata()
        {
            Configure(x => x.Begin)
                .DisplayName("Начало")
                .Format("{0:g}");

            Configure(x => x.End)
                .DisplayName("Окончание")
                .Format("{0:g}");

            Configure(x => x.Name)
                .DisplayName("Название встречи");

            Configure(x => x.Place)
                .DisplayName("Место проведения");

            Configure(x => x.Description)
                .DisplayName("Описание");
        }
    }
}
