﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OFM.TodoApp.Business.Interfaces;
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

            services.AddScoped<IUow, Uow>();

            services.AddScoped<IWorkService, WorkService>();
        }
    }
}