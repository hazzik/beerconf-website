namespace BeerConf.Web.Application.Account.Forms.Handlers
{
    using System;
    using Brandy.Core;
    using Brandy.Web.Forms;
    using Criteria;
    using Domain.Entities;
    using Services;

    public class SignInHandler : IFormHandler<SignIn>
    {
        private readonly IQueryBuilder query;
        private readonly IAuthenticationService service;

        public SignInHandler(IAuthenticationService service, IQueryBuilder query)
        {
            this.service = service;
            this.query = query;
        }

        #region IFormHandler<SignIn> Members

        public virtual void Handle(SignIn command)
        {
            User user = query.For<User>()
                .With(new FindByLoginOrEmail {LoginOrEmail = command.LoginOrEmail});

            if (user == null || user.Password.Check(command.Password) == false)
                throw new ApplicationException("Имя пользователя или пароль не верны");

            service.SignIn(user, command.RememberMe);
        }

        #endregion
    }
}
