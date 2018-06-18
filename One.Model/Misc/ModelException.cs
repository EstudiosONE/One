using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Model.Misc
{
    public class ModelException : SystemException
    {
        // Propiedades
        public int Code { get; }
        public override string Message { get; }
        // Constructores
        internal ModelException(ErrorCodeName errorCodeName)
        {
            Code = (int)errorCodeName;
            Message = ErrorCode.Single(x => x.Key == Code).Value;
        }

        // Metodos

        // Misc
        // Enumerado de codigos de error
        public enum ErrorCodeName
        {
            Auth_UserSecret_ReactiveSecret = 01002001
        }

        public static Dictionary<int, string> ErrorCode = new Dictionary<int, string>()
        {
            {01002001, "No es posible reactivar un secreto de usuario ya desactivado, verificar politicas de seguridad e ingresar como nuevo secreto."}
        };
    }
}
