using System;
using System.Collections.Generic;
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
            services.AddDbContext<CommonContext>(options => options.UseMySQL(Configuration.GetConnectionString("MySqlConnection")));

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
