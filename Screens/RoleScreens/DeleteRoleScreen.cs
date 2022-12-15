using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.RoleScreens
{
    public static class DeleteRoleScreen
    {
        public static void Load(SqlConnection connection)
        {

            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Qual Perfil deseja Deletar: ");

                ListRoleScreen.Lista(connection);

                Console.WriteLine();

                Console.Write("Digite o id do perfil: ");
                var id = int.Parse(Console.ReadLine());


                Console.Write("Ter certeza deseja deletar um role o processo é inrrevecivel digite (1) para sim (2) para não:");
                var verificacao = int.Parse(Console.ReadLine());

                if (verificacao == 1)
                {
                    // deletando uma linha da tabela role pelo id

                    var role = new Role();
                    role.Id = id;

                    var repository = new Repository<Role>(connection);

                    repository.Delete(role);

                    Console.Clear();

                    Console.WriteLine("Perfil deletado com sucesso realizado com sucesso!");
                    ListRoleScreen.Lista(connection);
                }
                else
                {
                    Console.WriteLine("OK, ate mais...");
                }

                Console.ReadKey();
                MenuRoleScreen.Load();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                DeleteRoleScreen.Load(connection);
            }
            finally { connection.Close(); }
        }
    }
}
