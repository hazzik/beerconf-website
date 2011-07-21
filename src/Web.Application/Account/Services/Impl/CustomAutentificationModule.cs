namespace BeerConf.Web.Application.Account.Services.Impl
{
    using System;
    using System.Security.Principal;
    using System.Threading;
    using System.Web;
    using System.Web.Security;

    /// <summary>
    /// Извлекает информацию о пользователе из тикета.
    /// </summary>
    public sealed class CustomAutentificationModule : IHttpModule
    {
        #region IHttpModule Members

        public void Init(HttpApplication httpApplication)
        {
            httpApplication.AuthenticateRequest += OnAuthenticateRequest;
        }

        public void Dispose()
        {
        }

        #endregion

        private static void OnAuthenticateRequest(object sender, EventArgs e)
        {
            var httpApplication = (HttpApplication) sender;

            HttpContext context = HttpContext.Current;

            if (context.User != null && context.User.Identity.IsAuthenticated)
                return;

            string cookieName = FormsAuthentication.FormsCookieName;

            HttpCookie cookie = httpApplication.Request.Cookies[cookieName.ToUpper()];

            if (cookie == null)
                return;
            try
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                var identity = new CustomIdentity(AccountEntry.Deserialize(ticket.UserData), ticket.Name);
                var principal = new GenericPrincipal(identity, identity.GetRoles());
                httpApplication.Context.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch
            {
            }
        }
    }
}
