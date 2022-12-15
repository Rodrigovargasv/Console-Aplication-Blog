using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.RoleScreens
{
    public static class CreateRoleScreen
    {
        public static void Load(SqlConnection connection)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.Write("Digite a quantidade de Perfil que deseja cadastrar: ");
                var quantidadeRole = int.Parse(Console.ReadLine());

                for (var i = 0; i < quantidadeRole; i++)
                {

                    Console.Write("digite o nome do perfil: ");
                    var name = Console.ReadLine();
        
                    Console.Write("Digite seu slug: ");
                    var slug = Console.ReadLine();

                    var role = new Role()
                    {
                        Name = name,
              
                        Slug = slug

                    };

                    var repository = new Repository<Role>(connection);
                    repository.Create(role);

                    Console.WriteLine();
                    Console.WriteLine("Perfils Cadastrado com sucesso!");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                    Console.ReadKey();
                    MenuRoleScreen.Load();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro " + ex.Message);
                CreateRoleScreen.Load(connection);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
