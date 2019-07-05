using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repository.DbContexts;
using Repository.IRepository;
using Swashbuckle.AspNetCore.Swagger;

namespace Web
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
            //数据库上下文
            services.AddDbContext<CommonContext>(options => options.UseMySQL(Configuration.GetConnectionString("MySqlConnection")));

            //注册仓储
            foreach (Type type in Assembly.Load(GetType().Assembly.GetName()).GetTypes())
            {
                if (typeof(IRepositoryBase<>).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                {
                    var interfaces = type.GetInterfaces();
                    foreach (var i in interfaces)
                    {
                        if (!i.IsGenericType && i != typeof(IRepositoryBase<>) && i.Name != typeof(IRepositoryBase<>).Name)
                        {
                            services.AddScoped(i, type);
                        }
                    }
                }
            }
            //注册swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = $"Api Doc",
                    Description = "Restful API Document",
                });

                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "Web.xml");
                c.IncludeXmlComments(xmlPath);
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
            });
            app.UseSwaggerUI(c => {
                c.RoutePrefix = "swagger/ui";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs"); });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
