namespace BeerConf.Web.Application.Account
{
    using System.Web.Mvc;
    using Brandy.Web.Forms;
    using Forms;

    public class AccountController : FormControllerBase
    {
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignIn command, string returnUrl)
        {
            return Handle(command, GetRedirectResult(returnUrl));
        }

        [CustomAuthorize]
        public ActionResult SignOut(SignOut command)
        {
            return Handle(command, RedirectToAction("Index", "Home"));
        }

        public ActionResult SignUp()
        {
            ViewBag.PasswordLength = 6;
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUp command)
        {
            return Handle(command, RedirectToAction("Index", "Home"));
        }

        [CustomAuthorize]
        public ActionResult ChangePassword()
        {
            ViewBag.PasswordLength = 6;
            return View();
        }

        [CustomAuthorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword command)
        {
            return Handle(command, RedirectToAction("ChangePasswordSuccess"));
        }

        [CustomAuthorize]
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        private ActionResult GetRedirectResult(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }
    }
}
