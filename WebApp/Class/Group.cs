namespace WebApp.Class
{
    public class Group
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public List<Post> ListaPosts { get; set; }

        public List<string> ListaMembros { get; set; }

        public string Link { get; set; }
    }
}
