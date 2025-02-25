using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Web.Common.ApplicationBuilder;

namespace LeedsSharp.Web.CustomRouting;

public class CustomRoutingComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.Configure<UmbracoPipelineOptions>(options =>
        {
            options.AddFilter(new UmbracoPipelineFilter("leedssharp")
            {
                Endpoints = app => app.UseEndpoints(endpoints =>
                {
                    endpoints.MapGet("/leedssharp", context => context.Response.WriteAsync("Hello Leeds!"));
                })
            });
            
            options.AddFilter(new UmbracoPipelineFilter(nameof(UmbBootstrapController))
            {
                Endpoints = app => app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute("example route", "/umbraco-bootstrap",
                        new { Controller = "UmbBootstrap", Action = "Index" });
                })
            });
        });
    }
}