using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IVVUO.INTEGRACIONES.Core.Requests
{
    public class IvvuoRequest
    {
        public IvvuoRequest(IServiceScopeFactory serviceScopeFactory)
        {
            var scope = serviceScopeFactory.CreateScope();
        }

        //public async static void crearOrden(string data)
        //{
        //    var url = $"https://mecappserver.herokuapp.com/erp/crearOrden";
        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    string json = $"{data}";
        //    request.Method = "POST";
        //    request.Headers["Authorization"] = "API Key eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjb2RlIjoiQ1MwMzgiLCJhY2NvdW50IjoiNWMyM2Q4YzZhZmFhOGIwMDA0M2UwODI4In0.H5EaRjQoQKAqWQSi76Pxm1j8t12Oqjbmg5neCwEwqA";
        //    request.ContentType = "application/json";
        //    request.Accept = "application/json";
        //    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        //    {
        //        streamWriter.Write(json);
        //        streamWriter.Flush();
        //        streamWriter.Close();
        //    }
        //    try
        //    {
        //        using (WebResponse response = request.GetResponse())
        //        {
        //            using (Stream strReader = response.GetResponseStream())
        //            {
        //                if (strReader == null) return;
        //                using (StreamReader objReader = new StreamReader(strReader))
        //                {
        //                    string responseBody = objReader.ReadToEnd();
        //                    // Do something with responseBody
        //                    Console.WriteLine(responseBody);
        //                }
        //            }
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        // Handle error
        //    }
        //}
    }
}
