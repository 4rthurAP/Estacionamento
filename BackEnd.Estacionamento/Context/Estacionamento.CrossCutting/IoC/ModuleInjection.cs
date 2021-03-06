using AutoMapper;
using Estacionamento.Domain.Contracts.Base;
using Estacionamento.Domain.Contracts.Notificator;
using Estacionamento.Domain.Contracts.Services;
using Estacionamento.Domain.Notificator;
using Estacionamento.Domain.Service;
using Estacionamento.Domain.Service.Base;
using Estacionamento.Domain.Services;
using Estacionamento.Infra.Repository.Base;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Estacionamento.CrossCutting.IoC
{
    public static class ModuleInjection
    {
        public static IServiceCollection AutoMapperModule(this IServiceCollection services) =>
             services.AddSingleton(new MapperConfiguration(mc => mc.AddMaps(AppDomain.CurrentDomain.GetAssemblies())).CreateMapper());

        public static IServiceCollection RegisterDI(this IServiceCollection services) =>
            services           
            .AddScoped<ILogService, LogService>()
            .AddScoped<IClientService, ClientService>()
            .AddScoped<INotificator, Notificator>()
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped(typeof(IService<>), typeof(Service<>))

 ;
    }
}
