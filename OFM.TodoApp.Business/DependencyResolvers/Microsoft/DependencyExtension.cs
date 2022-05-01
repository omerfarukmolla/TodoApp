using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OFM.TodoApp.Business.Interfaces;
using OFM.TodoApp.Business.Mapping.AuotMapperWork;
using OFM.TodoApp.Business.Services;
using OFM.TodoApp.DataAccess.Context;
using OFM.TodoApp.DataAccess.UnitOfWork;

namespace OFM.TodoApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("server=localhost\\SQLEXPRESS; database=TodoDb; integrated security=true;");
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);
            services.AddScoped<IUow, Uow>();

            services.AddScoped<IWorkService, WorkService>();
        }
    }
}
