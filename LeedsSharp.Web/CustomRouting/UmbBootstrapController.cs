using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace LeedsSharp.Web.CustomRouting;

public class UmbBootstrapController : UmbracoPageController, IVirtualPageController
{
    public UmbBootstrapController(ILogger<UmbracoPageController> logger, ICompositeViewEngine compositeViewEngine) : base(logger, compositeViewEngine)
    {
    }

    public IActionResult Index() => Ok(CurrentPage.Name);
    
    public IPublishedContent? FindContent(ActionExecutingContext actionExecutingContext)
    {
        var umbracoContextAccessor = actionExecutingContext.HttpContext.RequestServices
            .GetRequiredService<IUmbracoContextAccessor>();
        var umbracoContext = umbracoContextAccessor.GetRequiredUmbracoContext();
        //Contributed example this is not the best way of doing this.
        return umbracoContext.Content.GetAtRoot().DescendantsOrSelf<WebPage>().FirstOrDefault(x => x.Name == "UmBootstrap");
    }
}