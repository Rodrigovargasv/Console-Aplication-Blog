using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.PostScreens
{
    public static class CreatePostScreen
    {
        public static void Load(SqlConnection connection)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.Write("Digite a quantidade de Post que deseja cadastrar: ");
                var quantidadePost = int.Parse(Console.ReadLine());

                for (var i = 0; i < quantidadePost; i++)
                {

                    Console.Write("Digite o Id da categoria: ");
                    var repositoryCategory = new Repository<Category>(connection);
                    Category? categoryId = repositoryCategory.GetId(int.Parse(Console.ReadLine()));

                    Console.Write("Digite o Id do usuario(Author): ");
                    var repositoryUser = new Repository<User>(connection);
                    User? userId = repositoryUser.GetId(int.Parse(Console.ReadLine()));

                    Console.Write("Digite um novo titulo: ");
                    var title = Console.ReadLine();
                   

                    Console.Write("Digite um novo summary: ");
                    var summary = Console.ReadLine();

                    Console.Write("Digite um novo body: ");
                    var body = Console.ReadLine();

              
                    Console.Write("Digite um slug novo: ");
                    var slug = Console.ReadLine();

                    
                    if(categoryId == null || userId == null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Id de Categoria ou do Usurio não encontrado na base de dados tente novamente.");
                        Console.ReadKey();
                        Load(connection);

                    }
                    else
                    {
                        var post = new Post()
                        {

                            CategoryId = categoryId.Id,
                            AuthorId = userId.Id,
                            Title = title,
                            Summary = summary,
                            Body = body,
                            Slug = slug,
                            CreateDate = DateTime.Now,
                            LastUpdateDate= DateTime.Now,
                            
                        };

                        var repository = new Repository<Post>(connection);
                        repository.Create(post);

                        Console.WriteLine();
                        Console.WriteLine("Post Cadastrado com sucesso!");
                        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                        Console.ReadKey();
                        MenuPostScreen.Load();
                        
                    }
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro " + ex.Message);
                Console.ReadKey();
                CreatePostScreen.Load(connection);
            }
            finally
            {
                connection.Close();
            }
        }
    }

}
