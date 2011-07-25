namespace BeerConf.Web.Application.Account.Forms.Handlers
{
    using System;
    using Services;

    public class ChangePasswordHandler : FormHandlerBase<ChangePassword>
    {
        private readonly IContextUserProvider contextUserProvider;

        public ChangePasswordHandler(IContextUserProvider contextUserProvider)
        {
            this.contextUserProvider = contextUserProvider;
        }

        public override void Handle(ChangePassword command)
        {
            var user = contextUserProvider.ContextUser();

            if (user == null || !(user.Password.Check(command.OldPassword)))
                throw new ApplicationException("Неправильно указан текущий пароль");

            user.SetPassword(command.NewPassword);
        }
    }
}
