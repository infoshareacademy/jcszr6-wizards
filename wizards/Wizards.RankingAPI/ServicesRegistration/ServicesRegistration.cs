namespace Wizards.RankingAPI.ServicesRegistration
{
    public static class ServicesRegistration
    {
        public static void AddApi(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}