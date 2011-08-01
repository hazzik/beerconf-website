namespace BeerConf.Web.Application.Account.Services
{
    using Domain.Entities;

    public interface IContextUserProvider
    {
        User ContextUser();
        User ContextUser(bool shouldThrow);
    }
}