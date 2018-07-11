using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using One.Misc.Model;

namespace One.Auth.Model
{
    [Table(Name = "Auth.[User]")]
    public partial class User : Table
    {
        private string _Person;
        private StateName _State;

        public enum StateName
        {
            Pendiente = 0, Activo = 1, Suspendido = 3, Cancelado = 9
        }

        public User() : base() { }

        [Column(Storage = "_Person", DbType = "NChar(24)", CanBeNull = false)]
        public string Person
        {
            get => _Person;
            set { if (Person != value) Modify(value, out _Person); }
        }
        [Column(Storage = "_State", DbType = "NVarChar(24)")]
        public StateName State
        {
            get => _State;
            set { if (State != value) Modify(value, out _State); }
        }
    }
}
