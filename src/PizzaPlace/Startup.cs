using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PizzaPlace.Entities;

namespace PizzaPlace
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
			services.AddMemoryCache();

			services.AddSession( o => {
				o.CookieName = "Tomasos";
				o.CookieHttpOnly = true;
				o.IdleTimeout = TimeSpan.FromDays(1);
			});

			services.AddAuthorization(options =>
			{
				options.AddPolicy("AdministratorOnly", policy => policy.RequireRole("Admin"));
				options.AddPolicy("MembersOnly", policy => policy.RequireClaim("Member", "RegularUser", "PremiumUser", "Admin"));
			});

			services.AddDbContext<DatabaseContext>(s => s.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			
			services.AddMvc(config => {
				var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
				config.Filters.Add(new AuthorizeFilter(policy));
			});
		}

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

			app.UseCookieAuthentication(new CookieAuthenticationOptions()
			{
				AuthenticationScheme = "LoginCookie",
				ExpireTimeSpan = TimeSpan.FromSeconds(10),
				LoginPath = new PathString("/Account/Login/"),
				AccessDeniedPath = new PathString("/Account/Forbidden/"),
				AutomaticAuthenticate = true,
				AutomaticChallenge = true
			});

			app.UseStaticFiles();

			app.UseSession();

			app.UseMvcWithDefaultRoute();
        }
    }
}
