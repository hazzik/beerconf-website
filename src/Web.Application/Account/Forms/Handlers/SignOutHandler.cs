namespace BeerConf.Web.Application.Account.Forms.Handlers
{
    using Services;

    public class SignOutHandler : FormHandlerBase<SignOut>
    {
        private readonly IAuthenticationService service;

        public SignOutHandler(IAuthenticationService service)
        {
            this.service = service;
        }

        public override void Handle(SignOut command)
        {
            service.SignOut();
        }
    }
}
