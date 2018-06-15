using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using One.Model;

namespace One.Installer.DataBase.SQL
{
    internal class Schema
    {
        // Campos

        readonly SQLDriver Driver;


        // Constructores

        /// <summary>
        /// Engine de operaciones a nivel de esquema de base de datos
        /// </summary>
        /// <param name="driver">Driver de conexión de la base de datos</param>
        public Schema(SQLDriver driver)
        {
            Driver = driver;
        }

        // Metodos públicos


        public void CreateSchemaBase()
        {
            SqlConnection conn = new SqlConnection(Driver.Connection.ConnectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM sys.extended_properties where class = 0 and name = 'DatabaseVersion'", conn);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader["value"]));
                }
            }

            conn.Close();

            string[] schemas = new string[]
            {
                "Auth"
            };

            foreach (var schema in schemas)
            {
                try
                {
                    Driver.ExecuteCommand($"CREATE SCHEMA [{schema}]");
                }
                catch(SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 2714: break;
                        default: break;
                    }
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
