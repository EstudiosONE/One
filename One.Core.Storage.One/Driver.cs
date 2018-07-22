using One.Core.Auth.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Core.Storage.One
{
    internal class Driver
    {
        [Database(Name = "One")]
        public partial class SecundarioDataContext : System.Data.Linq.DataContext
        {

            private static MappingSource mappingSource = new AttributeMappingSource();

            #region Definiciones de métodos de extensibilidad
            partial void OnCreated();

            #region Auth
            partial void InsertToken(Token instance);
            partial void UpdateToken(Token instance);
            partial void DeleteToken(Token instance);
            #endregion

            #endregion

            public SecundarioDataContext() :
                    base("", mappingSource)
            {
                OnCreated();
            }

            public SecundarioDataContext(string connection) :
                    base(connection, mappingSource)
            {
                OnCreated();
            }

            public SecundarioDataContext(System.Data.IDbConnection connection) :
                    base(connection, mappingSource)
            {
                OnCreated();
            }

            public SecundarioDataContext(string connection, MappingSource mappingSource) :
                    base(connection, mappingSource)
            {
                OnCreated();
            }

            public SecundarioDataContext(System.Data.IDbConnection connection, MappingSource mappingSource) :
                    base(connection, mappingSource)
            {
                OnCreated();
            }

            public System.Data.Linq.Table<Token> Token
            {
                get
                {
                    return GetTable<Token>();
                }
            }
        }
    }
}
