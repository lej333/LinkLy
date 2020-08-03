using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using LinkLy.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using LinkLy.Helpers;
using LinkLy.Interfaces;
using Linkly.Data.Repositories;

namespace LinkLy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                     ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            
            services.AddScoped<IShortner>(options => {
                ShortnerConfig shortnerConfig = Configuration.GetSection("Shortner").Get<ShortnerConfig>();
                return new Shortner(shortnerConfig.Alphabet); 
            });

            services.AddScoped<IVisitor>(options => {
                VisitorConfig visitorConfig = Configuration.GetSection("Visitor").Get<VisitorConfig>();
                return new Visitor(visitorConfig.LookupUri);
            });

            Defaults defaults = Configuration.GetSection("Defaults").Get<Defaults>();
            services.AddScoped(options => defaults);

            services.AddScoped<LinkRepository>();
            services.AddScoped<UserSettingRepository>();
            services.AddScoped<DomainRepository>();
            services.AddScoped<ClickRepository>();
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddHttpContextAccessor();

            services.AddBrowserDetection();
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            dbInitializer.Initialize();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Admin}/{controller=Links}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "linkRequest",
                    pattern: "l/{*guid}",
                    defaults: new {
                        area = "Links",
                        controller = "LinkRequest",
                        action = "Index"
                    });

                endpoints.MapRazorPages();
            });
        }
    }
}
