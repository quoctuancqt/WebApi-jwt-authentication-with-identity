using DemoIdentity.Helpers;
using DemoIdentity.Identity;
using DemoIdentity.Services;
using JwtTokenServer.Extensions;
using JwtTokenServer.Proxies;
using JwtTokenServer.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoIdentity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMvc();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiPolicy", policy =>
                {
                    policy.AddRequirements(new ApiAuthorize());
                });
                options.AddPolicy("AdminPolicy", policy =>
                {
                    policy.AddRequirements(new AdminAuthorize());
                });
                options.AddPolicy("UserPolicy", policy =>
                {
                    policy.AddRequirements(new UserAuthorize());
                });
            });

            void customAuthenticationOptions(AuthenticationOptions options)
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

            services.JWTAddAuthentication(authenticationOptions: customAuthenticationOptions);

            services.AddSingleton<ITokenService, TokenService>();

            services.AddHttpClient<OAuthClient>(typeof(OAuthClient).Name, client => client.BaseAddress = new Uri("http://localhost:5050"));

            services.AddAccountManager<AccountManager>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IAccountService, AccountManager>();

            services.AddSingleton<IUserTwoFactorTokenProvider<ApplicationUser>, DataProtectorTokenProvider<ApplicationUser>>();

            ResolverFactory.SetProvider(services.BuildServiceProvider());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.JWTBearerToken(Configuration);

            app.UseMvc();
        }
    }
}
