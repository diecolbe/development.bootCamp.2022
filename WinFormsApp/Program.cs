using development.Application.Interfaces;
using development.Application.Services;
using development.Domain;
using development.Infrastructure.Interfaces;
using development.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            Application.Run(ServiceProvider.GetRequiredService<CreateStudentFrm>());
        }

        public static IServiceProvider? ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<CreateStudentFrm>();
                    services.AddTransient<IStudentService, StudentService>();
                    services.AddTransient<IStudentRepository, StudentRepository>();
                    services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
                    services.Configure<MongoDbSettings>(options =>
                    {
                        options.ConnectionString = "mongodb://localhost:27017";
                        options.DatabaseName = "development";
                    });
                    services.AddSingleton(serviceProvider =>
                    serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
                });
        }
    }
}