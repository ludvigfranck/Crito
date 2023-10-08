using Crito.Models;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers
{
    public class HomeController : SurfaceController
    {
        private readonly SubscriberService _subscriberService;
        public HomeController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, SubscriberService subscriberService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _subscriberService = subscriberService;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(NewsLetterForm newsLetterForm)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            if (await _subscriberService.AddSubscriberAsync(newsLetterForm) != null)
                return LocalRedirect("/subscribed");

            else
                ModelState.AddModelError("", "This Email already exists!");

            return CurrentUmbracoPage();
        }
    }
}
