using Blog.ConnectionDataBase;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            try
            {
                var connection = new SqlConnection(DataBase._connectionDataBase);

                Console.Clear();
                Console.WriteLine("Gestão de usuario");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Digite uma opção a baixo:");
                Console.WriteLine();
                Console.WriteLine("1 - Listar usuario ");
                Console.WriteLine("2 - Cadastrar usuario");
                Console.WriteLine("3 - Atualiza usuario");
                Console.WriteLine("4 - Deletar usuario");
                Console.WriteLine("5 - Sair");

                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                var option = short.Parse(Console.ReadLine());

                Console.Clear();
                switch (option)
                {
                    case 1:
                        ListUsersScreen.Lista(connection);
                        ListUsersScreen.Load();
                        break;
                    case 2:
                        CreateUserScreen.Load(connection);
                        break;
                    case 3:
                        UpdateUserScreen.Load(connection);
                        break;

                    case 4:
                        DeleteUserScreen.Load(connection);
                        break;
                    case 5:
                        Console.WriteLine("Volte sempre, ate mais!..");
                        break;

                    default:
                        Console.WriteLine("Opção invalida aperte qualquer tecla para continuar");
                        Console.ReadKey();
                        Load();
                        break;
                }
            }
            catch(Exception ex)
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
