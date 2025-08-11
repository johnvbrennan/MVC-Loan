using Autofac;
using Autofac.Extensions.DependencyInjection;
using Contoso.Loan.Mvc.Configuration;
using Contoso.Loan.MvcServices.Interfaces;
using Contoso.Loan.MvcServices.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<HomeLoanService>().As<IHomeLoanService>();
    containerBuilder.RegisterType<HomeLoanDefaultConfiguration>().As<ILoanDefaultConfiguration>();
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Loan}/{action=Index}/{id?}");

app.Run();
