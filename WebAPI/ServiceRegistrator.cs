using Core.DataWorker;
using Core.ExcelParser;
using Data.Repositories.Base;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public static class ServiceRegistrator
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseNpgsql("name=ConnectionStrings:HADB"));
            services.AddScoped<IExcelParser, ExcelParser>();
            services.AddScoped<IDataWorker, DataWorker>();
            services.AddScoped<IDbRepository<Transaction>, DbRepository <Transaction>>();
        }
    }
}