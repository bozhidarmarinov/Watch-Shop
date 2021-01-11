using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using onlineshop.Areas.Identity.Data;

[assembly: HostingStartup(typeof(onlineshop.Areas.Identity.IdentityHostingStartup))]
namespace onlineshop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<onlineshopIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("onlineshopIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<onlineshopIdentityDbContext>();
            });
        }
    }
}