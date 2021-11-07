using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Services.Interfaces;
using ShList.BlazorSrv.Services.Models;
using System;
using System.Net.Http;

namespace ShList.BlazorSrv
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod();
                    builder.WithOrigins("https://localhost:5101", "https://192.168.178.2:5101/");
                });
            });

            services.AddTransient<IRestService<Product>,ProductService>(); //This HAS TO BE BEFORE AddHttpClient
            services.AddHttpClient<IRestService<Product>, ProductService>(client => //This HAS TO BE AFTER AddTransient of services using it
                {
                    client.BaseAddress = new Uri(Configuration["ApiBaseAddress"]);
                });

            //services.AddTransient<IRestService<Product>, ProductService>(); //This HAS TO BE BEFORE AddHttpClient
            //services.AddHttpClient<IRestService<Product>, ProductService>(client => //This HAS TO BE AFTER AddTransient of services using it
            //{
            //    client.BaseAddress = new Uri(Configuration["ApiBaseAddress"]);
            //});


            services.AddRazorPages();
            services.AddServerSideBlazor();
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

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
