using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unsalted.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Unsalted.Areas.Identity.IdentityHostingStartup))]
namespace Unsalted.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ReviewContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ReviewContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ReviewContext>();
            });
        }
    }
}