namespace BeerConf.Web.Application.Events.Forms.Metadata
{
    using MvcExtensions;

    public class NewEventMetadata : ModelMetadataConfiguration<NewEvent>
    {
        public NewEventMetadata()
        {
            Configure(x => x.Begin)
                .DisplayName("Начало")
                .Template("DateTimePicker");

            Configure(x => x.End)
                .DisplayName("Окончание")
                .Template("DateTimePicker");

            Configure(x => x.Name)
             .DisplayName("Название встречи");

            Configure(x => x.Place)
                .DisplayName("Место проведения");

            Configure(x => x.Description)
                .DisplayName("Описание")
                .AsMultilineText();
        }   
    }
}