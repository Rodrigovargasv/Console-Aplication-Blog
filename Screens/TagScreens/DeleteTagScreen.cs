using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.TagScreens
{
    public static class DeleteTagScreen
    {

        // buscando uma lista de tags
        public static void Load(SqlConnection connection)
        {

            try
            {

                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Qual Tag deseja Deletar: ");

                ListTagScreen.Lista(connection);

                Console.WriteLine();

                Console.Write("Digite o ID da tag: ");
                var id = int.Parse(Console.ReadLine());


                Console.Write("Ter certeza deseja deletar uma Tag o processo é inrrevecivel digite (1) para sim (2) para não:");
                var verificacao = int.Parse(Console.ReadLine());

                if (verificacao == 1)
                {
                    // deletando uma linha da tabela tag pelo id

                    var tag = new Tag();
                    tag.Id = id;

                    var repository = new Repository<Tag>(connection);

                    repository.Delete(tag);


                    Console.Clear();

                    Console.WriteLine("Tag deletada com sucesso!");
                    ListTagScreen.Lista(connection);
                }
                else
                {
                    Console.WriteLine("OK, ate mais...");
                }

                Console.ReadKey();
                MenuTagScreen.Load();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                DeleteTagScreen.Load(connection);
            }
            finally { connection.Close(); }
        }

    }
}
