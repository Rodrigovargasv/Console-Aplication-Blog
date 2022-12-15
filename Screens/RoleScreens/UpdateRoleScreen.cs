using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.RoleScreens
{
    public static class UpdateRoleScreen
    {
        public static void Load(SqlConnection connection)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Qual Perfil deseja atualiza: ");


                ListRoleScreen.Lista(connection);

                Console.WriteLine();

                Console.Write("Digite o id do perfil: ");
                var id = int.Parse(Console.ReadLine());

                Console.Write("Qual novo nome: ");
                var name = Console.ReadLine();

                Console.Write("Qual novo slug: ");
                var slug = Console.ReadLine();


                var role = new Role()
                {
                    Id = id,
                    Name = name,
                    Slug = slug
                };

                var repository = new Repository<Role>(connection);

                // fazer um no usuaria com ID passado
                repository.Update(role);

                Console.Clear();


                Console.WriteLine("Perfil atualizado com sucesso!");
                ListRoleScreen.Lista(connection);
                ListRoleScreen.Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                UpdateRoleScreen.Load(connection);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
