using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

using Debie.Services;
using Debie.Services.Repositories;
using Debie.Services.Repositories.DB;

namespace Debie {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<DebieDBContext>(dbContextOptions =>
                dbContextOptions.UseMySql(
                    Configuration["ConnectionString"],
                    new MySqlServerVersion(new Version(8, 0, 22)),
                    mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)
                )
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
            );

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.EventsType = typeof(CookieEvents);
                    options.ReturnUrlParameter = "returnUrl";
                    options.LoginPath = new PathString("/Admin/Login");
                    options.LogoutPath = new PathString("/Admin/Logout");
                });

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<CookieEvents>();

            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Page}/{action=Index}/{id?}");
            });
        }
    }
}
