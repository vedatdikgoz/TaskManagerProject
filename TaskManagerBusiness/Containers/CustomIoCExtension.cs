
using Microsoft.Extensions.DependencyInjection;
using TaskManagerBusiness.Abstract;
using TaskManagerBusiness.Concrete;
using TaskManagerCore.DataAccess;
using TaskManagerCore.DataAccess.EntityFramework;
using TaskManagerDataAccess.Abstract;
using TaskManagerDataAccess.Concrete.Context;
using TaskManagerDataAccess.Concrete.EntityFramework;

namespace TaskManagerBusiness.Containers
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {

            services.AddScoped<IGorevService, GorevManager>();
            services.AddScoped<IGorevRepository, EfGorevRepository>();
           





        }
    }
}
