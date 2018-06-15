namespace One.Core.Config.Server.Connection.One.Model
{
    public class Integratd : ICredential
    {
        string ICredential.ToString()
        {
            return $"Integrated Security=True";
        }
    }
}
