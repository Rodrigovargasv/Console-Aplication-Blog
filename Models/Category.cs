using Dapper.Contrib.Extensions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    // referenciando a classe Category com a tabela Category NO BANCO DE DADOS.
    [Table("[Category]")]
    public class Category
    {
         
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        // construtor 
       //public Category()

            // iniciando a lista
          //=> Posts = new List<Post>();

        // referencia da classe post com a classe category, uma category tem varios post ou um list de post
        //public List<Post> Posts { get; set; }

    }
}
