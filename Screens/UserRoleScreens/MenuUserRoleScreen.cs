using Blog.ConnectionDataBase;
using Blog.Screens.RoleScreens;
using Blog.Screens.UserScreens;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserRoleScreens
{
    public static class MenuUserRoleScreen
    {
        public static void Load()
        {
            try
            {
                var connection = new SqlConnection(DataBase._connectionDataBase);

                Console.Clear();
                Console.WriteLine("Gestão de vinculo de perfil ao um usuario");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Digite a opção a baixo do que deseja realizar:");
                Console.WriteLine();
                Console.WriteLine("1 - Vincular Perfil a Usuario");
                Console.WriteLine("2 - Sair");

                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                var option = short.Parse(Console.ReadLine());

                Console.Clear();
                switch (option)
                {
                    case 1:
                        CreateUserRoleScreen.Load(connection);
                        break;
                    case 2:
                        Console.WriteLine("Volte sempre,ate mais.");
                        break;

                    default:
                        Console.WriteLine("Opção invalida aperte qualquer tecla para continuar");
                        Console.ReadKey();
                        Load();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Erro: " + ex.Message);
                Console.WriteLine("Opção invalida aperte qualquer tecla para continuar");
                Console.ReadKey();
                Load();
            }

        }
    }
}
