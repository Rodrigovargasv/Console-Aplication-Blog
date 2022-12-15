using Blog.ConnectionDataBase;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.ReportScreens
{
    public static class MenuReportScreen
    {
        public static void Load()
        {
            try
            {
                var connection = new SqlConnection(DataBase._connectionDataBase);

                Console.Clear();
                Console.WriteLine("Gestão de Report");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Digite a opção a baixo que deseja realizar:");
                Console.WriteLine();
                Console.WriteLine("1 - Listar Usuarios e seus Perfils");
                Console.WriteLine("2 - Lista Categorias com quantidade de Posts");
                Console.WriteLine("3 - Lista Tags com quantidade de Posts");
                Console.WriteLine("4 - Lista Post de uma Categoria");
                Console.WriteLine("5 - Lista de Categorias e Posts");
                Console.WriteLine("6 - Lista de Posts e Tags");
                Console.WriteLine("7 - Sair");

                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                var option = short.Parse(Console.ReadLine());

                Console.Clear();
                switch (option)
                {
                    case 1:
                        ListReportUserRoleScreen.Lista(connection);
                        ListReportUserRoleScreen.Load();

                        break;
                    case 2:
                        ListReportCategoryPostScreen.Lista(connection);
                        ListReportCategoryPostScreen.Load();
                        break;

                    case 3:
                        ListReportTagPostScreen.Lista(connection);
                        ListReportTagPostScreen.Load();
                        break;

                    case 4:
                        ListReportPostCategoryScreen.Lista(connection);
                        ListReportPostCategoryScreen.Load();
                        break;
                    case 5:
                        ListReportPostsCategorysScreen.Lista(connection);
                        ListReportPostsCategorysScreen.Load();
                        break;
                    case 6:
                        ListReportPostTagScreen.Lista(connection);
                        ListReportPostTagScreen.Load();
                        break;
                    case 7:
                        Console.WriteLine("ok, ate mais....");
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
                Console.WriteLine("Erro: " + ex.Message);
                Console.ReadKey();
                Load();
            }

        }
    }
}
