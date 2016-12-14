using Crud;
using Crud.App_Start.Bundle;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Crud
{
    public class AppHttp : HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalFilters.Filters.Add(new LogErroAttribute());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MvcHandler.DisableMvcResponseHeader = true;

            BundleTable.Bundles.Add(new StyleBundleConfig());
            BundleTable.Bundles.Add(new ScriptBundleConfig());
            BundleTable.EnableOptimizations = true;
        }
    }
}