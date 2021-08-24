using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace File.Api.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services,IConfiguration configuration);
    }
}
