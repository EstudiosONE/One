using One.Core.Config.Server.Connection.Paradise.Model;

namespace One.Core.Config.Server.Connection.Model
{
    public class Paradise
    {
        public string ServerAdress { get; }
        public string DatabaseName { get; }
        public ICredential Credential { get; }

        public Paradise(string serverAdress, string databaseName, ICredential credential)
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
