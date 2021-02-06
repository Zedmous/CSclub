using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club
{
    class MLogin
    {
        private string login;
        private string clave;

        public MLogin()
        {
            this.login = "USUARIO";
            this.clave = "123456";

        }
        public bool acceder(string login,string clave)
        {
            bool enc = false;
            if (this.login.Equals(login) && this.clave.Equals(clave))
            {
                enc = true;
            }
            return enc;
        }
        
    }
}
