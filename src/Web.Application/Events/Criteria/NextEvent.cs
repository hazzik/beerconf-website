namespace BeerConf.Web.Application.Events.Criteria
{
    using Brandy.Core;
    using Brandy.Security;
    using Brandy.Security.Entities;

    using Domain.Entities;

    public class NextEvent : ICriterion
    {
        public NextEvent(User user)
        {
            User = user;
        }

        public User User { get; private set; }
    }
}