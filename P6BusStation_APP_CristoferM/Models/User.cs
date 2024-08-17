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
    public class User
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }

        public int UsuarioID { get; set; }

        public string Correo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Contrasennia { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public int RolID { get; set; }

        public string RolDescripcion { get; set; } = null!;

        //función que permite agregar un usuario 
        public async Task<bool> AddUserAsync()
        {
            try
            {
                //este es el sufijo que completa la ruta de consumo del API
                string RouteSufix = string.Format("Users/AddUserFromApp");

                string URL = Services.WebAPIConnection.BaseURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                //agregamos la info de seguridad api key 
                Request.AddHeader(Services.WebAPIConnection.ApiKeyName,
                                  Services.WebAPIConnection.ApiKeyValue);

                //cuando enviamos objetos hacie el API debemos serializarlos antes

                string SerializedModel = JsonConvert.SerializeObject(this);

                Request.AddBody(SerializedModel);

                //se ejecuta la llamada 
                RestResponse response = await client.ExecuteAsync(Request);

                //validamos el resultado del llamado al API 
                HttpStatusCode statusCode = response.StatusCode;

                if (response != null && statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
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
