using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceLayer;
using StackExchange.Profiling.Storage;

namespace eShopWeb
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
            services.AddMiniProfiler(options =>
            {
                // All of this is optional. You can simply call .AddMiniProfiler() for all defaults

                // (Optional) Path to use for profiler URLs, default is /mini-profiler-resources
                options.RouteBasePath = "/profiler";

                // (Optional) Control storage
                // (default is 30 minutes in MemoryCacheStorage)
                (options.Storage as MemoryCacheStorage).CacheDuration = TimeSpan.FromMinutes(60);

                // (Optional) Control which SQL formatter to use, InlineFormatter is the default
                options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();

                // (Optional) To control authorization, you can use the Func<HttpRequest, bool> options:
                // (default is everyone can access profilers)
                //options.ResultsAuthorize = request => MyGetUserFunction(request).CanSeeMiniProfiler;
                //options.ResultsListAuthorize = request => MyGetUserFunction(request).CanSeeMiniProfiler;
                // Or, there are async versions available:
                //options.ResultsAuthorizeAsync = async request => (await MyGetUserFunctionAsync(request)).CanSeeMiniProfiler;
                //options.ResultsAuthorizeListAsync = async request => (await MyGetUserFunctionAsync(request)).CanSeeMiniProfilerLists;

                // (Optional)  To control which requests are profiled, use the Func<HttpRequest, bool> option:
                // (default is everything should be profiled)
                //options.ShouldProfile = request => MyShouldThisBeProfiledFunction(request);

                // (Optional) Profiles are stored under a user ID, function to get it:
                // (default is null, since above methods don't use it by default)
                //options.UserIdProvider = request => MyGetUserIdFunction(request);

                // (Optional) Swap out the entire profiler provider, if you want
                // (default handles async and works fine for almost all applications)
                //options.ProfilerProvider = new MyProfilerProvider();

                // (Optional) You can disable "Connection Open()", "Connection Close()" (and async variant) tracking.
                // (defaults to true, and connection opening/closing is tracked)
                options.TrackConnectionOpenClose = false;

                // (Optional) Use something other than the "light" color scheme.
                // (defaults to "light")
                //options.ColorScheme = StackExchange.Profiling.ColorScheme.Auto;
            }).AddEntityFramework();
            services.AddScoped<IeShopService, eShopService>();

            services.AddRazorPages();
            services.AddSession();
            services.AddDbContext<DataLayer.Entities.eShopContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("eShopContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IMemoryCache cache, eShopContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMiniProfiler();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            if (!db.Database.CanConnect())
            {
                db.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
