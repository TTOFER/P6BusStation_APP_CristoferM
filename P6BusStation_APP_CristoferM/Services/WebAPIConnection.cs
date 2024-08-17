using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6BusStation_APP_CristoferM.Services
{
    public static class WebAPIConnection
    {
        //configurar ruta de consumo base
        
        //variable
        public static string BaseURL = "http://192.168.100.9:45457/api/";

        //incluir info de seguridad
        //para los end point del API

        public static string ApiKeyName = "ApiKey";
        public static string ApiKeyValue = "CrisBUSP62024abx123";

    }
}
