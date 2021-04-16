using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WebApp.Models;

namespace WebApp
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

            // BookstoreDatabaseSettings
            services.Configure<BookstoreDatabaseSettings>(
                Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);
            

            // UserstoreDatabaseSettings
            services.Configure<UserstoreDatabaseSettings>(
                Configuration.GetSection(nameof(UserstoreDatabaseSettings)));

            services.AddSingleton<IUserstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<UserstoreDatabaseSettings>>().Value);


            // UsersBookshelfstoreDatabaseSettings
                        services.Configure<UsersBookshelfstoreDatabaseSettings>(
                Configuration.GetSection(nameof(UsersBookshelfstoreDatabaseSettings)));

            services.AddSingleton<IUsersBookshelfstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<UsersBookshelfstoreDatabaseSettings>>().Value);


            // UsersLikesstoreDatabaseSettings
            services.Configure<UsersLikesstoreDatabaseSettings>(
                Configuration.GetSection(nameof(UsersLikesstoreDatabaseSettings)));

            services.AddSingleton<IUsersLikesstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<UsersLikesstoreDatabaseSettings>>().Value);


            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
