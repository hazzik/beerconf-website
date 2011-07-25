namespace BeerConf.Web.Application.Account.Forms.Handlers
{
    using System;
    using Brandy.Web.Forms;
    using Domain.Entities;
    using Services;

    public class ChangePasswordHandler : IFormHandler<ChangePassword>
    {
        private readonly IContextUserProvider contextUserProvider;

        public ChangePasswordHandler(IContextUserProvider contextUserProvider)
        {
            this.contextUserProvider = contextUserProvider;
        }

        #region IFormHandler<ChangePassword> Members

        public virtual void Handle(ChangePassword command)
        {
            User user = contextUserProvider.ContextUser();

            if (user == null || !(user.Password.Check(command.OldPassword)))
                throw new ApplicationException("Неправильно указан текущий пароль");

            user.SetPassword(command.NewPassword);
        }

        #endregion
    }
}
