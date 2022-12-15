using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load(SqlConnection connection)
        {

            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Qual usuario deseja Deletar: ");

                ListUsersScreen.Lista(connection);

                Console.WriteLine();

                Console.Write("Digite o id da user: ");
                var id = int.Parse(Console.ReadLine());

                Console.Write("Ter certeza que deseja deletar um usuario o processo é inrrevecivel digite (1) para sim (2) para não: ");
                var verificacao = int.Parse(Console.ReadLine());

                if (verificacao == 1)
                {

                    // deletando uma linha da tabela tag pelo id
                    var user = new User();
                    user.Id = id;

                    var repository = new Repository<User>(connection);

                    repository.Delete(user);

                    Console.Clear();

                    Console.WriteLine("Usuario deletado com sucesso!");
                    ListUsersScreen.Lista(connection);
                }
                else
                {
                    Console.WriteLine("OK, ate mais...");
                }

                Console.ReadKey();
                MenuUserScreen.Load();

            }
            catch(Exception ex) 
            {
                Console.WriteLine("Erro: " + ex.Message);
                DeleteTagScreen.Load(connection);
            }
            finally { connection.Close(); }
        }
    }
}
