using AfsluttendeUmbracoProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;

namespace AfsluttendeUmbracoProjekt.Controllers
{
    public class GuestbookFormSurfaceController : SurfaceController
    {
        // GET: GuestbookFormSurface
        public ActionResult Index()
        {
            return PartialView("GuestbookForm", new GuestbookFormViewModel());
        }

        [HttpPost]
        public ActionResult CreateEntry(GuestbookFormViewModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            //Post comment
            Udi udi = Udi.Parse(@"umb://document/" + Umbraco.Content(Guid.Parse("97b96284-f968-4642-91b4-6d5a3ecfe555")));//Parse Udi for CreateContent().
            var newEntry = Services.ContentService.CreateContent(model.Title, udi, "guestbookEntry");
            newEntry.SetValue("title", model.Title);
            newEntry.SetValue("guestName", model.GuestName);
            newEntry.SetValue("date", DateTime.UtcNow);
            newEntry.SetValue("entryText", model.EntryText);
            Services.ContentService.SaveAndPublish(newEntry);

            TempData["success"] = true;
            return RedirectToCurrentUmbracoPage();
        }
    }
}