using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Core.Services;
using Umbraco.Core;

namespace AfsluttendeUmbracoProjekt.Controllers
{
    public class RegisterController : SurfaceController
    {
        // GET: Register
        public ActionResult Register(Models.RegisterModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            //create member code:
            var memberService = Services.MemberService;

            //Check that a member with entered email does not already exist.
            //If so: Return an error:
            if (memberService.GetByEmail(model.Email) != null)
            {
                ModelState.AddModelError("", "A member with this email already exists.");
                return CurrentUmbracoPage();
            }
            //If email is not already used, create member, save password and log them in right away:
            var member = memberService.CreateMemberWithIdentity(model.Email, model.Email, model.Name, "galleryMember");

            member.SetValue(Services.ContentTypeBaseServices, "avatar", model.Avatar.FileName, model.Avatar);

            memberService.Save(member);
            memberService.SavePassword(member, model.Password);

            Members.Login(model.Email, model.Password);
            //redirect member to homepage
            return RedirectToCurrentUmbracoPage();
        }
    }
}
