using P6BusStation_APP_CristoferM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6BusStation_APP_CristoferM.ViewModels
{
    internal class UserViewModel : BaseViewModel
    {
        public UserRole MyUserRole { get; set; }
        public User MyUser { get; set; }

        public UserViewModel()
        {
            MyUserRole = new UserRole();
            MyUser = new User();
        }

        //funcion cargar roles de usuario
        public async Task<List<UserRole>?> VmGetUserRolesAsync()
        {
            try
            {
                List<UserRole>? roles = new List<UserRole>();

                roles = await MyUserRole.GetUserRolesAsync();

                if (roles == null) return null;

                return roles;

            }
            catch (Exception)
            {
                throw;
            }
        }


        //funcion para agregar usuario
        public async Task<bool> VmAddUser(int pRoleID,
                                          string pEmail,
                                          string pUserName,
                                          string pPhoneNumber,
                                          string pPassword,
                                          string pAdress)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser = new()
                {
                    RolID = pRoleID,
                    Correo = pEmail,
                    Nombre = pUserName,
                    Telefono = pPhoneNumber,
                    Contrasennia = pPassword,
                    Direccion = pAdress
                };

                bool Ret = await MyUser.AddUserAsync();

                return Ret;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            { IsBusy = false; }

        }



    }
}
