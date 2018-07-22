namespace One.Core.Model.Storage.One
{
    public interface ICRUD
    {
        bool Create<T>(T instance);
        bool Update<T>(T instance);
        bool Delete<T>(T instance);
    }
}
