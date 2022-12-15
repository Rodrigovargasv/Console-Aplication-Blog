using Dapper.Contrib.Extensions;
using System;

namespace Blog.Models
{
    // referenciando a classe User com a tabela User NO BANCO DE DADOS.
    [Table("[User]")]
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }


        // lista de perfils relacionamento 1 para muitos, 1 user para muitos perfils
        [Computed]
        public List<Role> Roles { get; set; }

        // construtor padrão
        public User() { }

        // construtor com sobrecarga
        public User(Role item)
        {
            
            Roles = new List<Role>() { item };
        }
        

    }

}
