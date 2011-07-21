namespace BeerConf.Web.Application.Account.Forms.Handlers
{
    using System;
    using Brandy.Core;
    using Criteria;
    using Domain.Entities;
    using Services;

    public class SignUpHandler : FormHandlerBase<SignUp>
    {
        private readonly IAuthenticationService service;
        private readonly IRepository<User> userRepository;

        public SignUpHandler(IAuthenticationService service, IRepository<User> userRepository)
        {
            this.service = service;
            this.userRepository = userRepository;
        }

        public override void Handle(SignUp command)
        {
            IQueryBuilderWithPart<User> part = Query.For<User>();
            User rowCount = part.With(new FindByLoginOrEmail {LoginOrEmail = command.Login}) ??
                            part.With(new FindByLoginOrEmail {LoginOrEmail = command.Email});

            if (rowCount != null)
                throw new ApplicationException(
                    "В базе уже существует пользователь с таким именем или адресом электронной почты");

            var user = new User {EMail = command.Email, Login = command.Login};
            user.SetPassword(command.Password);
            userRepository.Add(user);

            service.SignIn(user, false);
        }
    }
}
