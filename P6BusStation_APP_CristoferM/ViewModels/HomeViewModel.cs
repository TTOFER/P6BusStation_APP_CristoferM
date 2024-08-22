using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P6BusStation_APP_CristoferM.Models;

namespace P6BusStation_APP_CristoferM.ViewModels
{
    internal class HomeViewModel : BaseViewModel
    {
        public Destination MyDestination { get; set; }

        public HomeViewModel()
        {
            MyDestination = new Destination();
        }

        //funcion cargar roles de usuario
        public async Task<List<Destination>?> VmGetDestinationsAsync()
        {
            try
            {
                List<Destination>? destinos = new List<Destination>();

                destinos = await MyDestination.GetDestinationsAsync();

                if (destinos == null) return null;

                return destinos;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
