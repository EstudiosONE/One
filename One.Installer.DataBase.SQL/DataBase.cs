using One.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Installer.DataBase.SQL
{
    class DataBase
    {        // Campos

        readonly SQLDriver Driver;


        // Constructores

        /// <summary>
        /// Engine de operaciones a nivel de esquema de base de datos
        /// </summary>
        /// <param name="driver">Driver de conexión de la base de datos</param>
        public DataBase(SQLDriver driver)
        {
            Driver = driver;
        }

        public void Initialize()
        {
            Driver.CreateDatabase();
        }
    }
}
