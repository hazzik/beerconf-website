namespace BeerConf.Web.Application.Account.Criteria
{
    using Brandy.Core;

    public class FindByLoginOrEmail : ICriterion
    {
        public string LoginOrEmail { get; set; }
    }
}
