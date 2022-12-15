using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.TagScreens
{
    public static class UpdateTagScreen
    {
        
        // buscando uma lista de tags
        public static void Load(SqlConnection connection)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Qual Tag deseja atualiza: ");


                ListTagScreen.Lista(connection);

                Console.WriteLine();

                Console.Write("Digite o id da tag: ");
                var id = int.Parse(Console.ReadLine());

                Console.Write("Qual novo nome: ");
                var name = Console.ReadLine();

                Console.Write("Qual novo slug: ");
                var slug = Console.ReadLine();


                var tag = new Tag()
                {
                    Id = id,
                    Name = name,
                    Slug = slug
                };

                var repository = new Repository<Tag>(connection);

                // fazer um no usuaria com ID passado
                repository.Update(tag);

                Console.Clear();


                Console.WriteLine("Tag atualizado com sucesso!");
                ListTagScreen.Lista(connection);
                ListTagScreen.Load();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                UpdateTagScreen.Load(connection);
            }
            finally
            {
                connection.Close();
            }
            
        }
    }
}
