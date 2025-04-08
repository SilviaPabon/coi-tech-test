namespace CoiServiceCrud.Models.Res
{
    public class Response
    {
        public int Success { get; set; }
        public object Data { get; set; }
        public Response() { 
            this.Success = 0;
        }
    }
}
