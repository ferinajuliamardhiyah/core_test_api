using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Threading.Tasks;
using core_test_api.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace core_test_api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllers ();
            services.AddDbContext<CoreDbContext> (bebas => bebas.UseMySql ("server=127.0.0.1;user id=root;password=Test123456789;port=3306;database=core_api_test"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure (IApplicationBuilder app, IHostEnvironment env, ILogger<Startup> logger) {
            if (env.IsDevelopment ()) {

                app.UseDeveloperExceptionPage ();
            }

            //app.UseHttpsRedirection();

            app.Use (async (context, next) => {
                string m_exePath = string.Empty;
                string log = $"[{DateTime.Now.ToString("s",DateTimeFormatInfo.InvariantInfo)}] {context.Request.Scheme} {context.Request.Method} {context.Request.Host}{context.Request.Path}";
                try {
                    using (StreamWriter w = File.AppendText ("request.log")) {
                        w.WriteLine (log);
                    }
                } catch (Exception ex) { }
                await next ();
            });

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}