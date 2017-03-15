using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Contoso.Loan.Mvc.Configuration;
using Contoso.Loan.MvcServices.Interfaces;
using Contoso.Loan.MvcServices.Services;
using Contoso.Loan.Services;

namespace Contoso.Loan.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IContainer Container { get; set; } 

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Autofac - IOC Registration
            var builder = new ContainerBuilder();
             
            builder.RegisterType<LoanService>().As<ILoanService>().InstancePerRequest();
            builder.RegisterType<HomeLoanService>().As<IHomeLoanService>().InstancePerRequest();
            builder.RegisterType<HomeLoanDefaultConfiguration>().As<ILoanDefaultConfiguration>().SingleInstance();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}
