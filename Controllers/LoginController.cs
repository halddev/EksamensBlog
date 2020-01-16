using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web.Models;

namespace AfsluttendeUmbracoProjekt.Controllers
{
    public class LoginController : SurfaceController
    {
        public ActionResult Login(LoginModel model)
        {
            if(!ModelState.IsValid)
                return CurrentUmbracoPage();

            if (Members.Login(model.Username, model.Password))
                return Redirect("/");

            ModelState.AddModelError("", "Invalid Login");
            return CurrentUmbracoPage();
        }

        public ActionResult Logout()
        {
            Members.Logout();
            return Redirect("/"); //logs out and redirects user to the home page instead.
        }
    }
}