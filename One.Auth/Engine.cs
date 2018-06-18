using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Auth
{
    public class Engine
    {
        public static void LogIn(string user, string password)
        {
            // Verificar usuario y contraseña.
            // {code}
        }
        public static void LogIn(string token)
        {
            // Verificar token.
            // {code}
        }
        public static void SetPin(string jwt, short pin) { }
        public static void Refresh(string jwt) { }
        public static void Verify(string jwt) { }
        public static void LogOut(string jwt) { }
    }
}
