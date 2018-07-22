namespace One.Core.Model.Storage.One.Service.Auth
{
    using global::One.Core.Model.Storage.One;

    public interface IToken : ICRUD
    {
        bool Read(string id, out Core.Auth.Model.IToken token);
    }
}