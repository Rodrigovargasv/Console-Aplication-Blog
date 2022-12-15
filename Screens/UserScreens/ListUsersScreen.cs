using Blog.Models;
using Blog.Repositories;

using Microsoft.Data.SqlClient;


namespace Blog.Screens.UserScreens
{
    public static class ListUsersScreen
    {
        public static void Lista(SqlConnection connection)
        {

            try

            {
                var repository = new Repository<User>(connection);

                var users = repository.Get();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                 Lista de usuario                     ");
                foreach (var user in users)
                {

                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine();
                    Console.Write($"Id: {user.Id} " +
                        $"Nome: {user.Name} " +
                        $"Slug: {user.Slug}");
                    Console.WriteLine();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                ListUsersScreen.Lista(connection);
            }
        }

        public static void Load()
        {
            Console.ReadKey();
            MenuUserScreen.Load();
        }
    }
}
