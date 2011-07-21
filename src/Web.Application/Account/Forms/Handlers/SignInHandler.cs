namespace BeerConf.Web.Application.Account.Forms.Handlers
{
    using System;
    using Criteria;
    using Domain.Entities;
    using Services;

    public class SignInHandler : FormHandlerBase<SignIn>
    {
        private readonly IAuthenticationService service;

        public SignInHandler(IAuthenticationService service)
        {
            this.service = service;
        }

        public override void Handle(SignIn command)
        {
            User user = Query.For<User>()
                .With(new FindByLoginOrEmail {LoginOrEmail = command.LoginOrEmail});

            if (user == null || user.Password.Check(command.Password) == false)
                throw new ApplicationException("Имя пользователя или пароль не верны");

            service.SignIn(user, command.RememberMe);
        }
    }
}
