using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebSocketApplication
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc();

            app.UseWebSockets();

            app.Use(async (http, next) =>
            {
                if (http.WebSockets.IsWebSocketRequest && http.Request.Path == "/ws")
                {
                    Program.wb = await http.WebSockets.AcceptWebSocketAsync();
                    await Task.Run(async () =>
                    {
                        while (Program.wb.State == System.Net.WebSockets.WebSocketState.Open)
                        {
                            byte[] bt = new byte[1024];
                            System.Net.WebSockets.WebSocketReceiveResult rc = await Program.wb.ReceiveAsync(bt, CancellationToken.None);

                            await Program.wb.SendAsync(bt, System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);
                        }

                    });
                }
                else
                {
                    await next();
                }
            });
        }
    }
}
