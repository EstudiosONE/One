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
    public class Token : Table
    {
        public Token() : base() { }

        private string _JWT;

        [Column(Storage = "_JWT", DbType = "nvarchar(1000)", CanBeNull = false)]
        public string JWT {
            get => _JWT;
            set
            {
                if(JWT != value)
                {
                    Modify(value, out _JWT);
                }
            }
        }
    }
}
