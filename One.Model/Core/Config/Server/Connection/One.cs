using One.Core.Config.Server.Connection.One.Model;

namespace One.Core.Config.Server.Connection.Model
{
    public class One
    {
        public string ServerAdress { get; }
        public string DatabaseName { get; }
        public ICredential Credential { get; }

        public One(string serverAdress, string databaseName, ICredential credential)
        {
            ServerAdress = serverAdress;
            DatabaseName = databaseName;
            Credential = credential;
        }

        public override string ToString()
        {
            return $"Data Source={ServerAdress};Initial Catalog={DatabaseName};{Credential.ToString()}";
        }
    }
}
