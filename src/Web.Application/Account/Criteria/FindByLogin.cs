namespace BeerConf.Web.Application.Account.Criteria
{
    using Brandy.Core;

    public class FindByLogin : ICriterion
    {
        public string Login { get; set; }
    }
}
