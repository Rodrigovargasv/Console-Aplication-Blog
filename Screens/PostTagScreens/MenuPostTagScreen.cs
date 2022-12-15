using Blog.ConnectionDataBase;
using Blog.Screens.PostScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserRoleScreens;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.PostTagScreens
{
    public static class MenuPostTagScreen
    {
        public static void Load()
        {
            try
            {
                var connection = new SqlConnection(DataBase._connectionDataBase);

                Console.Clear();
                Console.WriteLine("Gestão de vinculo de tag a um post");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Digite a opção a baixo do que deseja realizar:");
                Console.WriteLine();
                Console.WriteLine("1 - Vincular Tag a Post");
                Console.WriteLine("2 - Sair");

                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                var option = short.Parse(Console.ReadLine());

                Console.Clear();
                switch (option)
                {
                    case 1:
                        CreatePostTagScreen.Load(connection);
                        break;
                    case 2:
                        Console.WriteLine("ate mais.");
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
