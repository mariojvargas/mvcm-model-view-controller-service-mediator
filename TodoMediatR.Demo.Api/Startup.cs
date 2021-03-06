﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using MediatR;
using TodoApiMediatR.Demo.Api.Infrastructure.Data;
using AutoMapper;

namespace TodoApiMediatR.Demo.Api
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
            services.AddDbContext<TodoDbContext>(options => options.UseInMemoryDatabase("TodoList"));

            services.AddLogging(config => config.AddConsole());

            var currentAssembly = typeof(Startup).Assembly;
            services.AddMediatR(currentAssembly);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // See: https://github.com/AutoMapper/AutoMapper.Extensions.Microsoft.DependencyInjection
            services.AddAutoMapper(currentAssembly);
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
