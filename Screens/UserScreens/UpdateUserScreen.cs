using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreens
{
    public static class UpdateUserScreen
    {

        // buscando uma lista de tags
        public static void Load(SqlConnection connection)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Qual Usuario deseja atualiza: ");


                ListUsersScreen.Lista(connection);

                Console.WriteLine();

                Console.Write("Digite o id da usuario: ");
                var id = int.Parse(Console.ReadLine());

                Console.Write("digite um nome do usuario: ");
                var name = Console.ReadLine();

                Console.Write("Digite o Email do usuario: ");
                var email = Console.ReadLine();

                Console.Write("Digite uma nova senha: ");
                var senha = Console.ReadLine();

                Console.Write("Digite sua bio; ");
                var bio = Console.ReadLine();

                Console.Write("Adcione sua image: ");
                var image = Console.ReadLine();

                Console.Write("Digite seu slug: ");
                var slug = Console.ReadLine();


                var user = new User()
                {
                    Id = id,
                    Name = name,
                    Email = email,
                    PasswordHash = senha,
                    Bio = bio,
                    Image = image,
                    Slug = slug,
                    

                };


                var repository = new Repository<User>(connection);

                // fazer um  update no usuario com ID passado
                repository.Update(user);

                Console.Clear();


                Console.WriteLine("Usuarios atualizado com sucesso!");
                ListUsersScreen.Lista(connection);
                ListUsersScreen.Load();

            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Erro: " + ex.Message);
                Console.WriteLine("Aperte qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                UpdateUserScreen.Load(connection);
            }
        }
    }

}
    

