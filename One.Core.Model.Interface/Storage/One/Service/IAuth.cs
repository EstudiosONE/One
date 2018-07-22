namespace One.Core.Model.Storage.One.Service
{
    using global::One.Core.Model.Storage.One.Service.Auth;

    public interface IAuth
    {
        IToken Token { get; }
    }
}
