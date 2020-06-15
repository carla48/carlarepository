using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcaiAPI.Data;
using AcaiAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;

namespace AcaiAPI
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
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
            //services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("database"));
            services.AddScoped<ApplicationDbContext, ApplicationDbContext>();
            services.AddTransient<ISaborRepository, SaborRepository>();
            services.AddTransient<ITamanhoRepository, TamanhoRepository>();
            services.AddTransient<IPersonalizacaoRepository, PersonalizacaoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IPedidoPersonalizacaoRepository, PedidoPersonalizacaoRepository>();
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
