using System;
using KnightsBridge.Areas.Identity.Data;
using KnightsBridge.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(KnightsBridge.Areas.Identity.IdentityHostingStartup))]
namespace KnightsBridge.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<KnightsBridgeContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("KnightsBridgeContextConnection")));

                //services.AddDefaultIdentity<KnightsBridgeUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<KnightsBridgeContext>();
            });
        }
    }
}