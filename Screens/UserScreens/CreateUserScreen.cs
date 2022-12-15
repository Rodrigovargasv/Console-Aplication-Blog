using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load(SqlConnection connection)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.Write("Digite a quantidade de Usuarios que deseja cadastrar: ");
                var quantidadeUser = int.Parse(Console.ReadLine());

                for (var i = 0; i < quantidadeUser; i++)
                {

                    Console.Write("digite o nome do usuario: ");
                    var name = Console.ReadLine();

                    Console.Write("Digite o Email do usuario: ");
                    var email = Console.ReadLine();

                    Console.Write("Digite uma nova senha: ");
                    var senha = Console.ReadLine();

                    Console.Write("Digite sua bio: ");
                    var bio = Console.ReadLine();

                    Console.Write("Adcione sua image: ");
                    var image = Console.ReadLine();

                    Console.Write("Digite seu slug: ");
                    var slug = Console.ReadLine();
                   

                    var user = new User()
                    {
                        Name = name,
                        Email = email,
                        PasswordHash = senha,
                        Bio = bio,
                        Image = image,
                        Slug = slug,
                    };


                    var repository = new Repository<User>(connection);
                    repository.Create(user);
                    
                    Console.WriteLine();
                    Console.WriteLine("Usuario cadastrado com sucesso!");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

                    Console.ReadKey();
                    MenuUserScreen.Load();

                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro " + ex.Message);
                Console.ReadKey();
                CreateUserScreen.Load(connection);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
