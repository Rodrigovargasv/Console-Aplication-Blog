using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using System;


namespace Blog.Screens.PostScreens
{
    public static class UpdatePostScreen
    {
        public static void Load(SqlConnection connection)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Qual Post deseja atualiza: ");


                ListPostScreen.Lista(connection);

                Console.WriteLine();

                Console.Write("Digite o id da Category a ser atulizado: ");
                var id = int.Parse(Console.ReadLine());
                

                Console.Write("Digite um novo titulo: ");
                var title = Console.ReadLine();

                Console.Write("Digite um novo summary: ");
                var summary = Console.ReadLine();

                Console.Write("Digite um  novo body: ");
                var body = Console.ReadLine();


                Console.Write("Digite um novo slug: ");
                var slug = Console.ReadLine();

                var repository = new Repository<Post>(connection);

                var repositoryPost = repository.GetId(id);
               

                var post = new Post()
                {

                    CategoryId = repositoryPost.CategoryId,
                    AuthorId= repositoryPost.AuthorId,
                    Id = id,
                    Title = title,
                    Summary = summary,
                    Body = body,
                    Slug = slug,
                    CreateDate = repositoryPost.CreateDate,
                    LastUpdateDate = DateTime.Now
                    
                };
               
                

                // faze update em post com ID passado
                repository.Update(post);

                Console.Clear();


                Console.WriteLine("Post atualizado com sucesso!");
                ListPostScreen.Lista(connection);
                ListPostScreen.Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                Console.ReadKey();
                UpdatePostScreen.Load(connection);
            }
            finally
            {
                connection.Close();
            }


        }
    }
}
