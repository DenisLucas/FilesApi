using System;
using File.Infrastructure;
using File.Util.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace File.Api.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FileDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
                b => b.MigrationsAssembly("File.Infrastructure")));
            
            var assembly = AppDomain.CurrentDomain.Load("File.Core");
            services.AddMediatR(assembly);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<UrlHelper>(provider =>
                {
                    var acessor = provider.GetRequiredService<IHttpContextAccessor>();
                    var request = acessor.HttpContext.Request;
                    var absolutUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent(), "/");
                    return new UrlHelper(absolutUri);
                }
            );
        }
   
    }
}
