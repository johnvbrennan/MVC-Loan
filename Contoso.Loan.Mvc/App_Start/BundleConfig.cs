using System.Web.Optimization;

namespace Contoso.Loan.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        { 
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/lib/bootstrap").Include("~/lib/bootstrap/dist/css/bootstrap.min.css")); 
        }
    }
}
