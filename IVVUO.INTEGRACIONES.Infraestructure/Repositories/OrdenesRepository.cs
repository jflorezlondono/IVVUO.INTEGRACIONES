using IVVUO.INTEGRACIONES.Core.Entities;
using IVVUO.INTEGRACIONES.Core.Interfaces;
using MARESA.INTEGRACIONES.Infraestructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IVVUO.INTEGRACIONES.Infraestructure.Repositories
{
    public class OrdenesRepository : IOrdenesRepository
    {
        private readonly ApplicationDbContext _context;
        public OrdenesRepository(IServiceScopeFactory serviceScopeFactory)
        {
            var scope = serviceScopeFactory.CreateScope();
            _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }

        public async Task<List<OrdenesEntity>> GetSidaTalOrdenes(string emp)
        {
            //Datos quemados de momento (se debe hacer proceso de conexión con el sp)

            //var ordenes = new[] {
            //new  {or= "123123", name= "Jhonatan", last_name= "Florez", kiolometers= "50000",nit= "23122312",email= "prueba@gmail.com", telephone= "12312",plate= "1234",model= "captivaa",brand= "chevrolett",year= "2019",vin= "ASDASawA",accountId= "5c23d8c6afaa8b00043e0828",centerId= "5eb9ac3d915f9b0004ee7332",center_code= "CS038",account_code= "AC001" },
            //new  {or= "13221123", name= "Prueba", last_name= "aaaa", kiolometers= "50000",nit= "23122312",email= "prueba@gmail.com", telephone= "12312",plate= "1234",model= "captivaa",brand= "chevrolett",year= "2019",vin="ASDASawA",accountId= "5c23d8c6afaa8b00043e0828",centerId= "5eb9ac3d915f9b0004ee7332",center_code="CS038",account_code= "AC001"}};
            Console.WriteLine("Obteniendo ordenes de sida...");
            List<OrdenesEntity> Lista = new();

            Lista.Add(new OrdenesEntity { Or = "32432", Name = "Jhonatan", Last_name = "Florez", Kiolometers = "50000", Nit = "23122312", Email = "prueba@gmail.com", Telephone = "12312", Plate = "1234", Model = "captivaa", Brand = "chevrolett", Year = "2019", Vin = "ASDASawA", AccountId = "5c23d8c6afaa8b00043e0828", CenterId = "5eb9ac3d915f9b0004ee7332", Center_code = "CS038", Account_code = "AC001" });
            Lista.Add(new OrdenesEntity { Or = "13221123", Name = "Prueba", Last_name = "aaaa", Kiolometers = "50000", Nit = "23122312", Email = "prueba@gmail.com", Telephone = "12312", Plate = "1234", Model = "captivaa", Brand = "chevrolett", Year = "2019", Vin = "ASDASawA", AccountId = "5c23d8c6afaa8b00043e0828", CenterId = "5eb9ac3d915f9b0004ee7332", Center_code = "CS038", Account_code = "AC001" });

            return Lista;
        }

        //public async Task<string> crearOrden(string data)
        //{
        //    var url = $"https://mecappserver.herokuapp.com/erp/crearOrden";
        //    var jsonConvert = JObject.Parse(data);

            
        //    //var newJson = jsonConvert.ToString();
        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    //string json = $"{data}";
        //    string json = $"{{'or': '13221123','name': 'Jhonatan','last_name': 'Florez','kiolometers': '50000','nit': '23122312','email': 'prueba@gmail.com','telephone': '12312','plate': '1234','model': 'captivaa','brand': 'chevrolett','year': '2019','vin':'ASDASawA','accountId': '5c23d8c6afaa8b00043e0828','centerId': '5eb9ac3d915f9b0004ee7332','center_code':'CS038','account_code': 'AC001'}}";
        //    request.Method = "POST";
        //    request.Headers["Authorization"] = "API Key eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjb2RlIjoiQ1MwMzgiLCJhY2NvdW50IjoiNWMyM2Q4YzZhZmFhOGIwMDA0M2UwODI4In0.H5EaRjQoQKAqWQSi76Pxm1j8t12Oqjbmg5neCwEwqA";
        //    request.ContentType = "application/json";
        //    request.Accept = "application/json";
        //    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        //    {
        //        streamWriter.Write("{}");
        //        streamWriter.Flush();
        //        streamWriter.Close();
        //    }
        //    try
        //    {
        //        using (WebResponse response = request.GetResponse())
        //        {
        //            using (Stream strReader = response.GetResponseStream())
        //            {
        //                string responseBody = "";
        //                if (strReader == null)
        //                {
        //                    responseBody = "No se realizó registro";
        //                    return responseBody;
        //                }
        //                using (StreamReader objReader = new StreamReader(strReader))
        //                {
        //                     responseBody = objReader.ReadToEnd();
        //                    // Do something with responseBody
        //                    Console.WriteLine(responseBody);
        //                    return responseBody;
        //                }
        //            }
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        return "Se produjo un error";
        //    }
        //}

        public async Task<string> crearOrden(string orden)
        {
            try
            {
                Console.WriteLine("Generando orden de servicio con los datos encontrados...");
                var jsonConvert = JObject.Parse(orden);
                //Extraer valores del json
                var Or = JObject.Parse(jsonConvert.ToString())["Or"];
                var Name = JObject.Parse(jsonConvert.ToString())["Name"];
                var Last_name = JObject.Parse(jsonConvert.ToString())["Last_name"];
                var Kiolometers = JObject.Parse(jsonConvert.ToString())["Kiolometers"];
                var Nit = JObject.Parse(jsonConvert.ToString())["Nit"];
                var Email = JObject.Parse(jsonConvert.ToString())["Email"];
                var Telephone = JObject.Parse(jsonConvert.ToString())["Telephone"];
                var Plate = JObject.Parse(jsonConvert.ToString())["Plate"];
                var Model = JObject.Parse(jsonConvert.ToString())["Model"];
                var Brand = JObject.Parse(jsonConvert.ToString())["Brand"];
                var Year = JObject.Parse(jsonConvert.ToString())["Year"];
                var Vin = JObject.Parse(jsonConvert.ToString())["Vin"];
                var AccountId = JObject.Parse(jsonConvert.ToString())["AccountId"];
                var CenterId = JObject.Parse(jsonConvert.ToString())["CenterId"];
                var Center_code = JObject.Parse(jsonConvert.ToString())["Center_code"];
                var Account_code = JObject.Parse(jsonConvert.ToString())["Account_code"];
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri($"https://mecappserver.herokuapp.com/erp/crearOrden");
                httpClient.DefaultRequestHeaders.Add("api-key", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjb2RlIjoiQ1MwMzgiLCJhY2NvdW50IjoiNWMyM2Q4YzZhZmFhOGIwMDA0M2UwODI4In0.H5EaRjQoQKAqWQSi76Pxm1j8t12Oqjbmg5neCwEwqA");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );
                var data = new
                {
                    or = Or.ToString(),
                    name = Name.ToString(),
                    last_name = Last_name.ToString(),
                    kiolometers = Kiolometers.ToString(),
                    nit = Nit.ToString(),
                    email = Email.ToString(),
                    telephone = Telephone.ToString(),
                    plate = Plate.ToString(),
                    model = Model.ToString(),
                    brand = Brand.ToString(),
                    year = Year.ToString(),
                    vin = Vin.ToString(),
                    accountId = AccountId.ToString(),
                    centerId = CenterId.ToString(),
                    center_code = Center_code.ToString(),
                    account_code = Account_code.ToString()
                };
                Console.WriteLine("Conectando con el servidor https://mecappserver.herokuapp.com");
                string jsonData = JsonConvert.SerializeObject(data);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "UTF-8" };
                var response = await httpClient.PostAsync("", content);
                string jsonResult = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {

                    return jsonResult;
                }
                else
                {
                    return jsonResult;
                }
            }
            catch (Exception ex)
            {
                var error = "Se produjo un error al crear la orden";
                return error;
            }
        }
    }
}
