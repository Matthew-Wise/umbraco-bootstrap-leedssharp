using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace LeedsSharp.Web.Controllers;

public class HomeController : RenderController
{
    public HomeController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) 
        : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
    }
    
    /// <summary>
    /// The default action for the Content type
    /// </summary>
    /// <returns></returns>
    public override IActionResult Index()
    {
        return CurrentTemplate(CurrentPage);
    }

    /// <summary>
    /// Matches on template name
    /// </summary>
    /// <returns></returns>
    public IActionResult Home()
    {
        return View("~/Views/Home.cshtml", CurrentPage as Home);
    }
    
    /// <summary>
    /// Matches on template name
    /// </summary>
    /// <returns></returns>
    public IActionResult HomePage2()
    {
        return CurrentTemplate(CurrentPage);
    }
}