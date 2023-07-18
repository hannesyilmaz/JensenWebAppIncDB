namespace webapi.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Link { get; set; }
        public DateTime Published { get; set; }
        public string Topic { get; set; }
    }
}
