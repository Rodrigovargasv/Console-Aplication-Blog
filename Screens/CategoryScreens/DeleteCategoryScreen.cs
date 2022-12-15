using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.CategoryScreens
{
    public static class DeleteCategoryScreen
    {
        public static void Load(SqlConnection connection)
        {

            try
            {

                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Qual Category deseja Deletar: ");

                ListCategoryScreen.Lista(connection);

                Console.WriteLine();

                Console.Write("Digite o ID da Category: ");
                var id = int.Parse(Console.ReadLine());


                Console.Write("Ter certeza que deseja deletar uma Category o processo é inrrevecivel digite (1) para sim (2) para não:");
                var verificacao = int.Parse(Console.ReadLine());

                if (verificacao == 1)
                {
                    // deletando uma linha da tabela tag pelo id

                    var category = new Category();
                    category.Id = id;

                    var repository = new Repository<Category>(connection);

                    repository.Delete(category);


                    Console.Clear();

                    Console.WriteLine("Categoria deletada com sucesso realizado com sucesso!");
                    ListCategoryScreen.Lista(connection);
                }
                else
                {
                    Console.WriteLine("OK, ate mais...");
                }

                Console.ReadKey();
                MenuCategoryScreen.Load();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                DeleteCategoryScreen.Load(connection);
            }
            finally { connection.Close(); }
        }
    }
}
