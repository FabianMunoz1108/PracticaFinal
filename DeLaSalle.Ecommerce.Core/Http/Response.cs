namespace DeLaSalle.Ecommerce.Core.Http
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Messafe { get; set; } = "";
        public List<string> Errors { get; set; } = new List<string>();
    }
}
