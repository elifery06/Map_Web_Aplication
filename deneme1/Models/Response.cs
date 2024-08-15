namespace deneme1.Models
{
    public class Response<T>
    {
        public T Value { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }

        public Response(T value, bool result, string message)
        {
            Value = value;
            Result = result;
            Message = message;
        }
    }

    
}
