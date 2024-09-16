using BookHub.DataProvider;

namespace BookHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            try
            {
                var dbContext = services.GetRequiredService<BookContext>();
                if (dbContext.Database.EnsureCreated())
                    dbContext.DemoData(logger);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating database or adding demo data to database.");

                throw;
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
