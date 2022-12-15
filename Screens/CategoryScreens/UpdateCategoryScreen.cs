using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.CategoryScreens
{
    public static class UpdateCategoryScreen
    {
        public static void Load(SqlConnection connection)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Qual Category deseja atualiza: ");


                ListCategoryScreen.Lista(connection);

                Console.WriteLine();

                Console.Write("Digite o id da Category: ");
                var id = int.Parse(Console.ReadLine());

                Console.Write("Digite o nome da Category: ");
                var name = Console.ReadLine();

                Console.Write("Qual nome do Slug: ");
                var slug = Console.ReadLine();


                var category = new Category()
                {
                    Id = id,
                    Name = name,
                    Slug = slug
                };

                var repository = new Repository<Category>(connection);

                // fazer um no usuaria com ID passado
                repository.Update(category);

                Console.Clear();


                Console.WriteLine("Categoria atualizada com sucesso!");
                ListCategoryScreen.Lista(connection);
                ListCategoryScreen.Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                UpdateCategoryScreen.Load(connection);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
