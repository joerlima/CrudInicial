using System.Web.Optimization;

namespace Crud.App_Start.Bundle
{
    public class StyleBundleConfig : StyleBundle
    {
        public StyleBundleConfig()
            : base("~/Styles/app-css")
        {
            IncludeDirectory("~/Content/css/app", "*.css", true);
        }
    }
}