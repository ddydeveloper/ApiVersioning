using System;
using System.Collections.Generic;
using ApiVersioninig.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiVersioninig
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddVersionedApiExplorer(
                options =>
                {
                    options.SubstituteApiVersionInUrl = true;
                } );
            
            var apiV1 = new ApiVersion(1, 0);
            var apiV2 = new ApiVersion(2, 0);
            var apiV3 = new ApiVersion(3, 0);
            
            services.AddMvc();
            services.AddApiVersioning( options =>
            {
                //options.ApiVersionReader = new HeaderApiVersionReader("api-version" );
                
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(new DateTime(2017,1,1));
                //options.ApiVersionSelector = new LowestImplementedApiVersionSelector(options);
                
                options.Conventions.Controller<ConventionsBasedController>()
                    
                    .HasDeprecatedApiVersion(apiV1)
                    .HasApiVersion(apiV2)
                    .HasApiVersion(apiV3)
                    
                    .Action(c => c.Get()).MapToApiVersion(apiV1)
                    .Action(c => c.Post()).MapToApiVersion(apiV1)
                    .Action(c => c.Put()).MapToApiVersion(apiV1)
                    .Action(c => c.Delete()).MapToApiVersion(apiV1)
                    
                    .Action(c => c.GetV2()).MapToApiVersion(apiV2)
                    .Action(c => c.PostV2()).MapToApiVersion(apiV2)
                    .Action(c => c.PutV2()).MapToApiVersion(apiV2)
                    .Action(c => c.DeleteV2()).MapToApiVersion(apiV2)
                    
                    .Action(c => c.GetV3()).MapToApiVersion(apiV3)
                    .Action(c => c.PostV3()).MapToApiVersion(apiV3)
                    .Action(c => c.PutV3()).MapToApiVersion(apiV3)
                    .Action(c => c.DeleteV3()).MapToApiVersion(apiV3);
            });

            services.AddSwaggerGen(
                options =>
                {
                    var provider = services
                        .BuildServiceProvider()
                        .GetRequiredService<IApiVersionDescriptionProvider>();
                    
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(
                            description.GroupName, 
                            CreateInfoForApiVersion(description));
                    }

                    options.OperationFilter<SwaggerDefaultValues>();
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
        }

        private static Info CreateInfoForApiVersion( ApiVersionDescription description )
        {
            //TODO: customize this
            var info = new Info
            {
                Title = $"API {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = "API versioning.",
                Contact = new Contact() { Name = "D. D.", Email = "ddydeveloper@gmail.com" },
                TermsOfService = "Shareware",
                License = new License() { Name = "MIT", Url = "https://opensource.org/licenses/MIT" }
            };

            if ( description.IsDeprecated )
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}