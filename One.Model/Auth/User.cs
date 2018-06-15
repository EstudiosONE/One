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

namespace One.Model.Auth
{
    [Table(Name = "Auth.[User]")]
    public partial class User
    {
        private string _Id;
        private int _PaxCod;
        private string _State;

        public User()
        {
            _Id = LiteDB.ObjectId.NewObjectId().ToString();
        }

        [Column(Storage = "_Id", DbType = "NChar(24)", CanBeNull = false, IsPrimaryKey = true)]
        public string Id
        {
            get => _Id;
            set { if ((_Id != value)) Id = value; }
        }
        [Column(Storage = "_PaxCod", DbType = "Int", CanBeNull = false)]
        public int PaxCod
        {
            get => _PaxCod;
            set { if ((PaxCod != value)) _PaxCod = value; }
        }
        [Column(Storage = "_State", DbType = "NVarChar(50)")]
        public string State
        {
            get => _State;
            set { if ((_State != value)) _State = value; }
        }
    }
}
