using Dapper.Contrib.Extensions;


namespace Blog.Models
{

    // referenciando a classe TAG com a tabela TAG NO BANCO DE DADOS.
    [Table("[Tag]")]
   
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
