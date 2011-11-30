namespace BeerConf.Web.Application.Infrastructure
{
    using Domain.Entities;
    using Events.ViewModels;
    using MvcExtensions;
    using OoMapper;

    public class RegisterMappings : BootstrapperTask
    {
        public override TaskContinuation Execute()
        {
            Mapper.Reset();

            Mapper.CreateMap<Event, EventDetails>();

            Mapper.CreateMap<Event, AdminEventDetails>();
            
            Mapper.CreateMap<User, EventParticipant>();

            return TaskContinuation.Continue;
        }
    }
}
