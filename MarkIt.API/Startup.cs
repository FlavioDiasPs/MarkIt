﻿using MarkIt.Core.Interfaces.DbContext;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Core.Interfaces.Services;
using MarkIt.Core.Interfaces.Transactions;
using MarkIt.Core.Services;
using MarkIt.Infra.Data.DbContext;
using MarkIt.Infra.Data.Repositories;
using MarkIt.Infra.Data.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
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
            services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory<SqlConnection>>();
            services.AddTransient<IDbContext, DbContext>();

            services.AddTransient<IPriceService, PriceService>();
            services.AddTransient<IMarketService, MarketService>();
            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IPriceRepository, PriceRepository>();
            services.AddTransient<IMarketRepository, MarketRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opt => opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);
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
