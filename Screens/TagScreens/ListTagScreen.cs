using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.TagScreens
{
    public static class ListTagScreen 
    {
        // buscando uma lista de tags
        public static void Lista(SqlConnection connection)
        {

            try
            {
                var repository = new Repository<Tag>(connection);

                var tags = repository.Get();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                 Lista de Tags                     ");

                foreach (var tag in tags)
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine();
                    Console.Write($"Id: {tag.Id} " +
                        $"Nome: {tag.Name} " +
                        $"Slug: {tag.Slug}");
                    Console.WriteLine();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                Load();
            }
        }

        public static void Load()
        {
            Console.ReadKey();
            MenuTagScreen.Load();
        }

    }
}
