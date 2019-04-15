﻿using BookStore.Business;
using BookStore.Business.Services;
using BookStore.Entity.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace BookStoreMap
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

                // services.AddCors(c =>  
                // {  
                //     c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());

                //     c.AddPolicy("PostPolicy",
                //         builder => builder.AllowAnyOrigin()
                //         .WithMethods("POST")
                //         .WithHeaders("x-chmura-cors", "Content-Type"));  
                // });  

                services.AddCors(options =>
                    {
                        options.AddPolicy("AllowLocalhost",
                        builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
                    });

            var connectionString = Configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<BookDbContext>(options =>
               options.UseSqlServer(connectionString,
               b => b.MigrationsAssembly("BookStore.Api")));

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IPublisherService, PublisherService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("CoreSwagger", new Info
                {
                    Title = "BookMap Store Api",
                    Version = "1.0.0"
                });
            });
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

            // app.UseCors(options => options.AllowAnyOrigin() );
            app.UseCors("AllowLocalhost");

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "BookStoreMap");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}