namespace MetodosExtension.Model.Interface
{
    public interface IResponse
    {
        void SetError(string message);
        void SetOk(string message);
        bool GetSuccess();
        string GetMessage();
        T GetResult<T>();
        void SetResult<T>(T value);
    }
}