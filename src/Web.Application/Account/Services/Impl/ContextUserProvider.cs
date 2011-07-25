namespace BeerConf.Web.Application.Account.Services.Impl
{
    using System;
    using System.Web;
    using Brandy.Core;
    using Domain.Entities;

    public class ContextUserProvider : IContextUserProvider
    {
        private readonly IRepository<User> userRepository;

        public ContextUserProvider(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public User ContextUser()
        {
            return userRepository.Get(Identity().Id);
        }

        private static CustomIdentity Identity()
        {
            var identity = HttpContext.Current.User.Identity as CustomIdentity;
            if (identity == null)
                throw new NotSupportedException();
            return identity;
        }
    }
}