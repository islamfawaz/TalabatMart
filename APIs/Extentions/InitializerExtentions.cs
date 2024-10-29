using Domain.Contracts.Persistence;

namespace APIs.Extentions
{
    public static class InitializerExtentions
    {
        public static async Task<WebApplication> InitializeDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateAsyncScope();
            var services = scope.ServiceProvider;
            var storeContextInitializer = services.GetRequiredService<IStoreDbInitializer>();

            //Ask run tim enviroment for object from store context explicitly

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await storeContextInitializer.InitializeAsync();
                await storeContextInitializer.Seeds();


            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "error has been occur during apply migration");

                throw;
            }

            return app;
        }
    }

}
