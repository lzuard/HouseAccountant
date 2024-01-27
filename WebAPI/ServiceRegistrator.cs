using Core.ExcelParser;

namespace WebAPI
{
    public static class ServiceRegistrator
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IExcelParser, ExcelParser>();
        }
    }
}
