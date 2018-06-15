namespace One.Core.Config.Server.Connection.Paradise.Model
{
    public class Integratd : ICredential
    {
        string ICredential.ToString()
        {
            return $"Integrated Security=True";
        }
    }
}
