using System;
using File.Core.Filters;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace File.Api.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddMvc(options =>
               options.Filters.Add<ValidationFilters>()
            );
            
            var assembly = AppDomain.CurrentDomain.Load("File.Core");
            services.AddFluentValidation(mvcConfiguration=> mvcConfiguration.RegisterValidatorsFromAssembly(assembly));

            
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "File", Version = "v1" });
            });
        }
    }
}
