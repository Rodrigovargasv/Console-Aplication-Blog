using Blog.Models;
using Blog.Repositories;
using Blog.Screens.RoleScreens;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.PostScreens
{
    public static class ListPostScreen
    {
        public static void Lista(SqlConnection connection)
        {

            try

            {
                var repository = new Repository<Post>(connection);

                var posts = repository.Get();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                 Lista de Post                     ");

                foreach (var post in posts)
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine();
                    Console.Write($"Id: {post.Id} " +
                        $"Nome: {post.Title} " +
                        $"Slug: {post.Slug}");
                    Console.WriteLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                ListPostScreen.Lista(connection);
            }
        }

        public static void Load()
        {
            Console.ReadKey();
            MenuPostScreen.Load();
        }
    }
}
    

