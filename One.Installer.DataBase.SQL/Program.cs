using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using One.Model;
using Auth = One.Model.Auth;

namespace One.Installer.DataBase.SQL
{
    class Program
    {
        static readonly SQLDriver Driver;

        static Program()
        {
            Driver = new SQLDriver();
        }
        static void Main(string[] args)
        {
            new DataBase(Driver).Initialize();
            new Schema(Driver).CreateSchemaBase();

            string sentence = "";
            var metaTable = Driver.Mapping.GetTable(typeof(Auth.User));
            sentence += $"CREATE TABLE {metaTable.TableName} (";
            for (int i = 0; i < metaTable.RowType.DataMembers.Count; i++)
            {
                var member = metaTable.RowType.DataMembers[i];
                sentence += $" {member.Name} {member.DbType} {(member.CanBeNull ? "NULL" : "NOT NULL")}{((metaTable.RowType.DataMembers.Count - i) > 1? ", ": " ")}";
            }
            sentence += ") ON[PRIMARY]";
            var PrimaryKeys = (from x in metaTable.RowType.DataMembers where x.IsPrimaryKey select x).ToList();
            if (PrimaryKeys.Count > 0)
            {
                sentence += $" ALTER TABLE {metaTable.TableName} ADD CONSTRAINT PK_{metaTable.RowType.Name} PRIMARY KEY CLUSTERED (";
                for (int i = 0; i < PrimaryKeys.Count; i++)
                {
                    sentence += $" {PrimaryKeys[i].Name}{((PrimaryKeys.Count - i) > 1 ? ", " : " ")}";
                }
                sentence += ") WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";
            }
            try
            {
                Driver.ExecuteCommand(sentence);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2714:

                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
