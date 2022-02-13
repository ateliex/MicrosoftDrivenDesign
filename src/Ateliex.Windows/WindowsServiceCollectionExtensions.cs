using Ateliex.Areas.Cadastro.Windows;
using Ateliex.Areas.Comercial.Windows;
using Ateliex.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Ateliex
{
    public static class WindowsServiceCollectionExtensions
    {
        public static IServiceCollection AddWindows(this IServiceCollection services)
        {
            services.AddTransient(typeof(MainWindow));

            services.AddTransient(typeof(ModeloWindow));

            services.AddTransient(typeof(ModeloConsultaWindow));

            services.AddTransient(typeof(PlanoComercialWindow));

            return services;
        }
    }
}
