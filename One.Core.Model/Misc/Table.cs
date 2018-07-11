using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Misc.Model
{
    public class Table
    {
        // Campos de tabla
        protected string _Id;
        protected DateTime _CreationDate;
        protected DateTime _ModificationDate;

        // Propiedades de tabla
        [Column(Storage = "_Id", DbType = "NChar(24)", CanBeNull = false, IsPrimaryKey = true)]
        public string Id
        {
            get => _Id;
        }
        [Column(Storage = "_CreationDate", DbType = "datetime", CanBeNull = false)]
        public DateTime CreationDate
        {
            get => _CreationDate;
        }
        [Column(Storage = "_ModificationDate", DbType = "datetime", CanBeNull = true)]
        public DateTime ModificationDate
        {
            get => _ModificationDate;
        }

        // Constructores
        public Table()
        {
            _Id = LiteDB.ObjectId.NewObjectId().ToString();
            _CreationDate = DateTime.Now;
            _ModificationDate = DateTime.Now;
        }

        // Metodos de manipulación de datos
        protected void Modify<T>(T value, out T field)
        {
            field = value;
            _ModificationDate = DateTime.Now;
        }
    }
}
