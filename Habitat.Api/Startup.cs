using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Habitat.Application.Interfaces;
using Habitat.Application.Notes.Commands;
using Habitat.Application.Notes.Queries;
using Habitat.DataAccess;
using Habitat.DataAccess.Interfaces;
using Habitat.DataAccess.Repositories;
using Habitat.News;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

namespace Habitat.Api
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
            services.AddCors(options =>
                options.AddPolicy(name: "AllowedCORS",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            services.AddControllers();

            services.AddDbContext<HabitatContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("HabitatDb")));

            services.AddTransient<IHabitatContext, HabitatContext>();

            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IGetAllNotesQuery, GetAllNotesQuery>();
            services.AddScoped<IAddNotesCommand, AddNotesCommand>();
            services.AddScoped<IUpdateNotesCommand, UpdateNotesCommand>();
            services.AddScoped<IGetTodaysNotesQuery, GetTodaysNotesQuery>();
            services.AddScoped<IHabitatNews, HabitatNews>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Habit@",
                    Version = "v1",
                    Description = "API Backend for Habit@ Project for DevPost The Global Hack"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowedCORS");

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Habit@");
                c.RoutePrefix = string.Empty;
            });

        }
    }
}