namespace BeerConf.Infrastructure.NHibernate.Queries.Account
{
    using System.Linq;
    using Brandy.Core;
    using Brandy.NHibernate;
    using Domain.Entities;
    using Web.Application.Account.Criteria;

    public class FindByLoginQuery : NHibernateLinqQueryBase<User, FindByLogin>
    {
        public FindByLoginQuery(ILinqProvider linqProvider) : base(linqProvider)
        {
        }

        public override User Ask(FindByLogin criterion)
        {
            return Query<User>()
                .Where(x => x.Login == criterion.Login)
                .SingleOrDefault();
        }
    }
}
