
using System.ComponentModel.DataAnnotations.Schema;


namespace Blog.Models
{  
    
    // referenciando a classe Role com a tabela Role NO BANCO DE DADOS.
    [Table("[Role]")]

    public class Role
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        

    }
}
