using One.Misc.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Core.Auth.Model
{
    [Table(Name = "Auth.[Token]")]
    public class Token_db : Table
    {
        #region Constructores
        public Token_db() : base() { }
        #endregion

        #region Campos
        private string _JWT;
        #endregion

        #region Propiedades
        [Column(Storage = "_JWT", DbType = "nvarchar(1000)", CanBeNull = false)]
        public string JWT
        {
            get => _JWT;
            set
            {
                if (JWT != value)
                {
                    Modify(value, out _JWT);
                }
            }
        }
        #endregion
    }

    public class Token : Token_db
    {
        public UserRole Role { get; }

        public class UserRole
        {
            #region Metodos
            /// <summary>
            /// Convierte la representación de cadena especificada de un objeto UserRole y devuelve un valor que indica si la conversión se realizó correctamente.
            /// </summary>
            /// <param name="value">Cadena que contiene on objeto UserRole serializado como Json.</param>
            /// <param name="result">El resultado que devuelve este método contiene el objeto UserRole, en caso de producirse un error éste parametro se devuelve null</param>
            /// <returns>true si el parámetro value se convierte correctamente; en caso contrario, false.</returns>
            public static bool TryParse(string value, out UserRole result)
            {
                try
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<UserRole>(value);
                    return true;
                }
                catch
                {
                    result = null;
                    return false;
                }
            }

            public override string ToString()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }
            #endregion
        }
    }
}
