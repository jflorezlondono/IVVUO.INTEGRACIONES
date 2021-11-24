using AutoMapper;
using IVVUO.INTEGRACIONES.Core.Interfaces;
using IVVUO.INTEGRACIONES.Infraestructure.Mappings;
using IVVUO.INTEGRACIONES.Infraestructure.Repositories;
using MARESA.INTEGRACIONES.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVVUO.INTEGRACIONES.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;

                    services.AddSingleton(configuration);
                    // Auto Mapper Configurations
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new AutomapperProfile());
                    });

                    IMapper mapper = mappingConfig.CreateMapper();
                    services.AddSingleton(mapper);

                    services.AddTransient<IOrdenesRepository, OrdenesRepository>();
                    services.AddTransient<IInventoryRepository, InventoryRepository>();

                    //Configuración para db e inyectar dbContext para worker service
                    var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                    optionBuilder.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
                    services.AddScoped(s => new ApplicationDbContext(optionBuilder.Options));

                    services.AddHostedService<Worker>();
                });
    }
}
