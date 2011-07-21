namespace BeerConf.Infrastructure.NHibernate.Queries.Account
{
    using System.Linq;
    using Brandy.Core;
    using Brandy.NHibernate;
    using Domain.Entities;
    using Web.Application.Account.Criteria;

    public class FindByLoginOrEmailQuery : NHibernateLinqQueryBase<User, FindByLoginOrEmail>
    {
        public FindByLoginOrEmailQuery(ILinqProvider linqProvider)
            : base(linqProvider)
        {
        }

        public override User Ask(FindByLoginOrEmail criterion)
        {
            return Query<User>()
                .Where(x => x.Login == criterion.LoginOrEmail || x.EMail == criterion.LoginOrEmail)
                .SingleOrDefault();
        }
    }
}
