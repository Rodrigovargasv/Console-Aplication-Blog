using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.PostScreens
{
    public static class DeletePostScreen
    {
        public static void Load(SqlConnection connection)
        {

            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Qual Post deseja Deletar: ");

                ListPostScreen.Lista(connection);

                Console.WriteLine();

                Console.Write("Digite o id da Post: ");
                var id = int.Parse(Console.ReadLine());


                Console.Write("Ter certeza que deseja deletar um Post o processo é inrrevecivel digite (1) para sim (2) para não:");
                var verificacao = int.Parse(Console.ReadLine());

                if (verificacao == 1)
                {
                    // deletando uma linha da tabela role pelo id

                    var post = new Post();
                    post.Id = id;

                    var repository = new Repository<Post>(connection);

                    repository.Delete(post);

                    Console.Clear();

                    Console.WriteLine("Post deletado com sucesso!");
                    ListPostScreen.Lista(connection);
                }
                else
                {
                    Console.WriteLine("OK, ate mais...");
                }

                Console.ReadKey();
                MenuPostScreen.Load();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                DeletePostScreen.Load(connection);
            }
            finally { connection.Close(); }
        }
    }

}

