namespace One.Core.Config.Server.Connection.Paradise.Model
{
    public class Standard : ICredential
    {
        internal string User { get; }
        internal string Password { get; }

        public Standard(string user, string password)
        {
            User = user;
            Password = password;
        }

        string ICredential.ToString()
        {
            return $"User ID={User};Password={Password}";
        }
    }
}
