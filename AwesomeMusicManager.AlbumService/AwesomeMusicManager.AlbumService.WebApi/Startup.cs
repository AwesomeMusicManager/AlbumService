using System;
using System.Reflection;
using AwesomeMusicManager.AlbumService.Infrastructure;
using AwesomeMusicManager.AlbumService.Model.Commands;
using AwesomeMusicManager.AlbumService.Model.Interfaces;
using AwesomeMusicManager.AlbumService.Service;
using AwesomeMusicManager.AlbumService.Service.CommandHandlers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AwesomeMusicManager.AlbumService.WebApi
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
            MongoRepository.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            MongoRepository.DatabaseName = Configuration.GetSection("MongoConnection:Database").Value;
            MongoRepository.IsSSL = Convert.ToBoolean(this.Configuration.GetSection("MongoConnection:IsSSL").Value);

            services.AddScoped<IAlbumService, Service.AlbumService>();
            services.AddScoped<IMongoRepository, MongoRepository>();

            var assembly = AppDomain.CurrentDomain.Load("AwesomeMusicManager.AlbumService.Service");

            services.AddMediatR(typeof(CommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddAlbumCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(EditAlbumCommand).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(AddAlbumCommand));
            services.AddMediatR(typeof(EditAlbumCommand));

            services.AddControllers();

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Album API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Album API V1");
            });

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.UseRouting();

            app.UseCors(option => option.AllowAnyOrigin());

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}