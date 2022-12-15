using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserRoleScreens;
using Dapper;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.ReportScreens
{
    public static class ListReportPostCategoryScreen
    {

        public static void Lista(SqlConnection connection)
        {


            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.Write("Digite a quantidade de Post de uma categoria que deseja lista: ");
                var quantidadePost = int.Parse(Console.ReadLine());

                for (var i = 0; i < quantidadePost; i++)
                {
                    Console.Write("Digite o id da Category a ser para lista seus posts ");
                    var repositoryCategory = new Repository<Category>(connection);
                    Category? category = repositoryCategory.GetId(int.Parse(Console.ReadLine()));
                    

                    if (category == null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Id da Category não encontrado na base de dados tente novamente.");
                        Console.ReadKey();
                        Lista(connection);
                    }
                    else
                    {


                        var repositoryPost = new Repository<Post>(connection);
                        var post = repositoryPost.Get();

                        Console.WriteLine();
                        Console.WriteLine("--------------------------------------------Lista de Posts desta Categoria--------------------------------------------");
                        Console.WriteLine();

                        foreach (var item in post)
                        {
                            if(item.CategoryId == category.Id)
                            {
                                
                                Console.WriteLine($"Id = {item.Id}, CategoryId = {item.CategoryId}, AuthorId = {item.AuthorId}, Title = {item.Title}, Summary = {item.Summary}, Body = {item.Body}, Slug = {item.Slug}");
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro " + ex.Message);
                Console.ReadKey();
                ListReportPostCategoryScreen.Lista(connection);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void Load()
        {
            Console.ReadKey();

            MenuReportScreen.Load();
        }
    }
}
