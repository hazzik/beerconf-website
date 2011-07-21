namespace BeerConf.Web.Application.Account.Forms.Handlers
{
    using System;
    using System.Web;
    using Criteria;
    using Domain.Entities;

    public class ChangePasswordHandler : FormHandlerBase<ChangePassword>
    {
        public override void Handle(ChangePassword command)
        {
            string userName = HttpContext.Current.User.Identity.Name;

            User user = Query.For<User>()
                .With(new FindByLogin {Login = userName});

            if (user == null || !(user.Password.Check(command.OldPassword)))
                throw new ApplicationException("Неправильно указан текущий пароль");

            user.SetPassword(command.NewPassword);
        }
    }
}
