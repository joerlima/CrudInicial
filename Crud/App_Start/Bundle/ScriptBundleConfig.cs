using System.Web.Optimization;

namespace Crud.App_Start.Bundle
{
    public class ScriptBundleConfig : ScriptBundle
    {
        public ScriptBundleConfig()
            : base("~/Scripts/app-js")
        {
            Include("~/Scripts/Vendor/jquery-{version}.js");
            Include("~/Scripts/Vendor/jquery.validate*");
            Include("~/Scripts/Vendor/jquery.mask.min.js");
            Include("~/Scripts/Vendor/modernizr-*");
            Include("~/Scripts/Vendor/bootstrap.js", "~/Scripts/respond.js");
            Include("~/Scripts/Vendor/angular.js");
            IncludeDirectory("~/Scripts/App/Modules", "*.js", true);
            IncludeDirectory("~/Scripts/App/Directives", "*.js", true);
            IncludeDirectory("~/Scripts/App/Services", "*.js", true);
            IncludeDirectory("~/Scripts/App/Controllers", "*.js", true);
        }
    }
}