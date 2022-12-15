
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.RoleScreens;
using Blog.Screens.UserScreens;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.UserRoleScreens
{
    public static class CreateUserRoleScreen 
    {
        public static void Load(SqlConnection connection)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.Write("Digite a quantidade de perfil que deseja vincula a um usuario: ");
                var quantidadePerfil = int.Parse(Console.ReadLine());

                for (var i = 0; i < quantidadePerfil; i++)
                {
                    Console.Write("Digite o id do Perfil a ser vinculado ao Usuario: ");
                    var repositoryRole = new Repository<Role>(connection);
                    Role? perfilId = repositoryRole.GetId(int.Parse(Console.ReadLine()));


                    Console.WriteLine("Digite o id do Usurio a ser vinculado ao Perfil: ");
                    var repositoryUser = new Repository<User>(connection);
                    User? userId = repositoryUser.GetId(int.Parse(Console.ReadLine()));


                    if (perfilId == null || userId == null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Id do Perfil ou do Usuario não encontrado na base de dados tente novamente.");
                        Console.ReadKey();
                        Load(connection);
                    }
                    else
                    {                        
                        var user = new User(perfilId)
                        {
                            Roles = new List<Role> { perfilId },
                            Id = userId.Id,
                        };

        
                        foreach (var item in user.Roles)
                        {

                            var userRole = new UserRole
                            {
                                UserId = user.Id,
                                RoleId = item.Id
                            };

                            var repository = new Repository<UserRole>(connection);
                            repository.Create(userRole);

                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Vinculo realizado com sucesso!");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                    Console.ReadKey();
                    MenuUserRoleScreen.Load();

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Erro " + ex.Message);
                CreateUserRoleScreen.Load(connection);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
