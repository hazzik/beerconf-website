namespace BeerConf.Web.Application.Account.Forms
{
    using Brandy.Web.Forms;

    public class SignIn : IForm
    {
        public string LoginOrEmail { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}