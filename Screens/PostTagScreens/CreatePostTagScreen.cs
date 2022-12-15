using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.PostTagScreens
{
    public static class CreatePostTagScreen
    {
        public static void Load(SqlConnection connection)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.Write("Digite a quantidade de Post que deseja vincula a um Tag: ");
                var quantidadePost = int.Parse(Console.ReadLine());


                for (var i = 0; i < quantidadePost; i++)
                {
                    Console.Write("Digite o Id do Post que deseja vincular a Tag: ");
                    var repositoryPost = new Repository<Post>(connection);
                    Post? postId = repositoryPost.GetId(int.Parse(Console.ReadLine()));


                    Console.Write("Digite o Id do Tag que deseja vincular a Post: ");
                    var repositoryTag = new Repository<Tag>(connection);
                    Tag? tagId = repositoryTag.GetId(int.Parse(Console.ReadLine()));


                    if (postId != null || tagId != null)
                    {
                        var post = new Post() { Id = postId.Id };
                        var tag = new Tag() { Id = tagId.Id };

                        var postTag = new PostTag() { PostId = post.Id, TagId = tag.Id };
                        var repository = new Repository<PostTag>(connection);
                        repository.Create(postTag);

                    }
                    else
                    {
                        
                        Console.WriteLine();
                        Console.WriteLine("Id do Perfil ou do usuario não encontrado na base de dados tente novamente.");
                        Console.ReadKey();
                        Load(connection);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Vinculo realizado com sucesso!");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                    Console.ReadKey();
                    MenuPostTagScreen.Load();

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro " + ex.Message);
                CreatePostTagScreen.Load(connection);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
