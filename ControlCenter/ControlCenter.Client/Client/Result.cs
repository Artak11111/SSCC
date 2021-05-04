namespace ControlCenter.Client.Client
{
    public class RequestResult<T>
    {
        public T Result { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class RequestResult
    {

        public string ErrorMessage { get; set; }
    }
}
