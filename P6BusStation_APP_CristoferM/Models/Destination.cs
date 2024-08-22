using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace P6BusStation_APP_CristoferM.Models
{
    class Destination
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }

        public int DestinationID { get; set; }

        public string DestinationName { get; set; } = null!;

        //funcion que entrega todos los roles desde al API

        public async Task<List<Destination>?> GetDestinationsAsync()
        {
            try
            {
                string RouterSufix = string.Format("Destinations");

                string URL = Services.WebAPIConnection.BaseURL + RouterSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //info de seguridad ApiKey
                Request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);

                //ejecutar llamada
                RestResponse response = await client.ExecuteAsync(Request);

                //validar resultado del llamado al API
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<Destination>>(response.Content);

                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }
    }
}
