using AndreGutierrez.Application.UFs.Queries;
using AndreGutierrez.Domain.Cidades;
using AndreGutierrez.Domain.Common;
using AndreGutierrez.Domain.Estados;
using AndreGutierrez.Domain.Pessoas;
using AndreGutierrez.Infra.Data;
using AndreGutierrez.Infra.Data.Domain;
using FLT.Core.Infra.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Infra.CrossCutting.IoC;

public class NativeInjector
{
    public static void Setup(IServiceCollection services, IConfiguration configuration)
    {
        RegisterServices(services, configuration);
        RegisterInfraData(services, configuration);
    }

    private static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(ListaCidadesQuery)); 
    }

    private static void RegisterInfraData(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = 
            Environment.GetEnvironmentVariable("DEFAULT_CONNECTION") ??
            configuration.GetConnectionString("DefaultConnection");

        Console.WriteLine(connectionString);

        services.AddDbContext<DesafioContext>(o => o
            .UseLazyLoadingProxies()
            .UseSqlServer(connectionString)
        );

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEstadoRepository, EstadoRepository>();
        services.AddScoped<IPessoaRepository, PessoaRepository>();
        services.AddScoped<ICidadeRepository, CidadeRepository>();
    }
}

