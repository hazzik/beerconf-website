namespace BeerConf.Web.Application.Events.ViewModels.Metadata
{
    public class AdminEventDetailsMetadata : EventDetailsMetadataBase<AdminEventDetails>
    {
        public AdminEventDetailsMetadata()
        {
            Configure(x => x.Participants)
                .Order(800)
                .DisplayName("Участники")
                .Template("Table");
        }
    }
}