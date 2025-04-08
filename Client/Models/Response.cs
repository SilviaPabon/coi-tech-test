namespace Client.Models
{
    public class Response<T>
    {
        public int Success { get; set; }
        public T Data { get; set; } = default!;
    }
}
