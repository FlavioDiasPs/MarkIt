using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Core.Interfaces.Services;
using MarkIt.Core.Services;
using MarkIt.Infra.Data.DapperConfig;
using MarkIt.Infra.Data.Repositories;
using MarkIt.Infra.Data.Transactions;
using MarkIt.Infra.Data.Transactions.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace MarkIt.Api
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
            services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory<SqlConnection>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IMarketService, MarketService>();
            services.AddTransient<IProductService, ProductService>();            

            services.AddTransient<IMarketRepository, MarketRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
