using One.Misc.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Auth.Model
{
    [Table(Name = "Auth.[UserSecret]")]
    public class UserSecret : Table
    {
        bool _IsActualSecret;

        // Propiedades de tabla
        [Column(Storage = "_ModificationDate", DbType = "datetime", CanBeNull = false, IsPrimaryKey = true)]
        public new DateTime ModificationDate
        {
            get => _ModificationDate;
        }
        [Column(DbType = "nchar(24)", CanBeNull = false)]
        public string User { get; }
        [Column(DbType = "binary", CanBeNull = false)]
        public byte[] Secret { get; }
        [Column(Storage = "_IsActualSecret", DbType = "bit", CanBeNull = false)]
        public bool IsActualSecret
        {
            get => _IsActualSecret;
            set
            {
                if (value != IsActualSecret & !value) Modify(value, out _IsActualSecret);
                else if (value) throw new ModelException(ModelException.ErrorCodeName.Auth_UserSecret_ReactiveSecret);
            }
        }

        // Constructores
        internal UserSecret() 
            : base()
        {
            _IsActualSecret = true;
        }
        public UserSecret(string user, byte[] secret) : base()
        {
            _IsActualSecret = true;
            User = user;
            Secret = secret;
        }

        // Metodos
    }
}
