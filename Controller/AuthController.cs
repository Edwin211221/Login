using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Controllers
{
    class AuthController
    {
        private Models.LoginModel _loginModel = new Models.LoginModel();
       
        public string login(Models.LoginModel Usuario)
        {
            return _loginModel.VerificarLogin(Usuario);
        }

        public void logOut()
        {
            Program.Nombreusuario = "";
            Program.Estado = 0;
            Program.UsuarioId = 0;
        }
    }
}

