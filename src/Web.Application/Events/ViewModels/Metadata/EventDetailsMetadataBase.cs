namespace BeerConf.Web.Application.Events.ViewModels.Metadata
{
    using MvcExtensions;

    public class EventDetailsMetadataBase<TEventDetails> : ModelMetadataConfiguration<TEventDetails>
        where TEventDetails : EventDetails
    {
        public EventDetailsMetadataBase()
        {
            Configure(x => x.Begin)
                .DisplayName("Начало")
                .Order(100)
                .Format("{0:g}");

            Configure(x => x.End)
                .DisplayName("Окончание")
                .Order(200)
                .Format("{0:g}");

            Configure(x => x.Name)
                .Order(300)
                .DisplayName("Название встречи");

            Configure(x => x.Place)
                .Order(400)
                .DisplayName("Место проведения");

            Configure(x => x.AvailablePlaces)
                .Order(500)
                .DisplayName("Мест осталось")
                .NullDisplayText("Не ограничено");

            Configure(x => x.Description)
                .Order(700)
                .DisplayName("Описание");
        }
    }
}