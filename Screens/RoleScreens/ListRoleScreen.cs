using Blog.Models;
using Blog.Repositories;

using Microsoft.Data.SqlClient;


namespace Blog.Screens.RoleScreens
{
    public static class ListRoleScreen
    {
        public static void Lista(SqlConnection connection)
        {

            try

            {
                var repository = new Repository<Role>(connection);

                var roles = repository.Get();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                 Lista de Role                     ");

                foreach (var role in roles)
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine();
                    Console.Write($"Id: {role.Id} " +
                        $"Nome: {role.Name} " +
                        $"Slug: {role.Slug}");
                    Console.WriteLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                ListRoleScreen.Lista(connection);
            }
        }

        public static void Load()
        {
            Console.ReadKey();
            MenuRoleScreen.Load();
        }
    }
}
           
