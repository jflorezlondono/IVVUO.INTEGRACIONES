using AutoMapper;
using IVVUO.INTEGRACIONES.Core.Entities;
using IVVUO.INTEGRACIONES.Core.Interfaces;
using IVVUO.INTEGRACIONES.Core.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace IVVUO.INTEGRACIONES.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IOrdenesRepository _ordenes;
        private readonly IvvuoRequest _ivvuo;
        private readonly IConfiguration _configuracion;
        private readonly IMapper mapper;
        private string frecuencia;
        private int tiempo;
        private int milisegundos;

        public Worker(ILogger<Worker> logger, IConfiguration configuracion, IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        {
            _logger = logger;
            _configuracion = configuracion;
            this.mapper = mapper;
            using (var scope = serviceScopeFactory.CreateScope())
            {
                _ordenes = scope.ServiceProvider.GetService<IOrdenesRepository>();
                _ivvuo = scope.ServiceProvider.GetService<IvvuoRequest>();
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                frecuencia = _configuracion["Ejecucion:Frecuencia"];
                tiempo = Convert.ToInt32(_configuracion["Ejecucion:Tiempo"]);

                Console.WriteLine("----------Frecuencia Ejecucion----------");
                _logger.LogInformation($"Cada {tiempo} {frecuencia} Se ejecutará");
                Console.WriteLine("----------------------------------------");

                switch (frecuencia)
                {
                    case "H":
                        milisegundos = tiempo * 60 * 60 * 1000;
                        break;
                    case "M":
                        milisegundos = tiempo * 60 * 1000;
                        break;
                    case "S":
                        milisegundos = tiempo * 1000;
                        break;
                    default:
                        milisegundos = 60 * 1000;
                        break;
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                try
                {
                    var emp = _configuracion["Ivvuo:emp"];
                    var isNumeric = int.TryParse(emp, out int n);
                    if (!isNumeric)//Validar campo númerico
                    {
                        _logger.LogError("El parametro emp debe ser númerico");
                    }
                    else
                    {
                        var ordenes = await _ordenes.GetSidaTalOrdenes(emp);
                        if (ordenes.Any())
                        {
                            var dataOrdenes = mapper.Map<List<OrdenesEntity>>(ordenes);
                            foreach (var item in dataOrdenes)
                            {
                                var json = JsonSerializer.Serialize(item);
                                var postOrdenes = await _ordenes.crearOrden(json);
                                var responseOrden = JObject.Parse(postOrdenes);
                                var data = JObject.Parse(responseOrden.ToString())["data"];
                                var validatePayload = JObject.Parse(data.ToString())["payload"];
                                if (validatePayload != null)
                                {
                                    var dataPayload = JObject.Parse(validatePayload.ToString())["shortUrl"];
                                    _logger.LogInformation($"La orden {dataPayload} se generó correctamente");
                                }
                                else
                                {
                                    _logger.LogWarning("La orden ya existe");
                                }
                                _logger.LogInformation(postOrdenes);
                            }

                        }
                    }

                    
                }
                catch (Exception e)
                {

                    throw;
                }

                await Task.Delay(milisegundos, stoppingToken);

            }
        }
    }
}
