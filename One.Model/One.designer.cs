namespace One.Model
{
    using System.Data.Linq.Mapping;
    using System.Data.Linq.SqlClient;

    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name="One")]
    [Provider(typeof(Sql2008Provider))]
    public partial class SQLDriver : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    #endregion
		
		public SQLDriver() : 
				base(global::One.Model.Properties.Settings.Default.OneConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SQLDriver(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLDriver(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLDriver(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLDriver(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Auth.User> Auth_User
		{
			get
			{
				return this.GetTable<Auth.User>();
			}
		}
	}
}
