using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Habitat.Application.Interfaces;
using Habitat.Application.Notes.Commands;
using Habitat.Application.Notes.Queries;
using Habitat.Application.Todos;
using Habitat.Application.Todos.Commands;
using Habitat.Application.Users;
using Habitat.Application.Users.Commands;
using Habitat.Application.Users.Queries;
using Habitat.DataAccess;
using Habitat.DataAccess.Interfaces;
using Habitat.DataAccess.Notes;
using Habitat.DataAccess.Repositories;
using Habitat.DataAccess.Todos;
using Habitat.DataAccess.Users;
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
            services.AddControllers();
            
            services.AddDbContext<HabitatContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("HabitatDb")));

            services.AddTransient<IHabitatContext, HabitatContext>();

            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IUpdateNotesCommand, UpdateNotesCommand>();
            services.AddScoped<IDeleteNotesCommand, DeleteNotesCommand>();
            services.AddScoped<IAddNotesCommand, AddNotesCommand>();
            services.AddScoped<IGetAllNotesQuery, GetAllNotesQuery>();
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAddUsersCommand, AddUsersCommand>();
            services.AddScoped<IGetUsersByUsernamesQuery, GetUsersByUsernamesQuery>();
            services.AddScoped<IGetTodaysNotesQuery, GetTodaysNotesQuery>();

            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IAddTodosCommand, AddTodosCommand>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Habit@",
                    Version = "v1",
                    Description = "API Backend for Habit@ Project for DevPost The Global Hack"
                });
                c.EnableAnnotations();
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