namespace deneme1.Models
{
    public class Response : Item
    {
        public Object Value { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }

        public Response(Object value, bool result, string message)
        {
            Value = value;
            Result = result;
            Message = message;
        }
    }

    
}
