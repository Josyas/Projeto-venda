using FluentValidation;
using FluentValidation.AspNetCore;
using Venda_BackEnd.Data;
using Venda_BackEnd.Entites;
using Venda_BackEnd.FluentValidador;
using Venda_BackEnd.Repository;
using Venda_BackEnd.Repository.Interface;
using Venda_BackEnd.Service;
using Venda_BackEnd.Service.Interface;
using Venda_BackEnd.Validadors;

namespace Venda_BackEnd.DependenciesExtension
{
    public static class DependenciesExtension
    {
        public static void AddMySqlConnection(this IServiceCollection services)
        {
            services.AddScoped<ConexaoDB>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteReposiotrio, ClienteRepositorio>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<ICategoriaService, CategoriaService>();
        }

        public static void AddValidation(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<ClienteValidator>());
            services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<CategoriaValidator>());
        }
    }
}
