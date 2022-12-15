using Blog.ConnectionDataBase;
using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.CategoryScreens
{
    public static class MenuCategoryScreen
    {
        public static void Load()
        {
            try
            {
                var connection = new SqlConnection(DataBase._connectionDataBase);

                Console.Clear();
                Console.WriteLine("Gestão de Categoria");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Digite a opção a baixo que deseja realizar:");
                Console.WriteLine();
                Console.WriteLine("1 - Listar categoria");
                Console.WriteLine("2 - Cadastrar categoria");
                Console.WriteLine("3 - Atualiza categoria");
                Console.WriteLine("4 - Deletar categoria");
                Console.WriteLine("5 - Sair");

                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                var option = short.Parse(Console.ReadLine());

                Console.Clear();
                switch (option)
                {
                    case 1:
                        ListCategoryScreen.Lista(connection);
                        ListCategoryScreen.Load();

                        break;
                    case 2:
                        CreateCategory.Load(connection);
                        break;
                    case 3:
                        UpdateCategoryScreen.Load(connection);
                        break;

                    case 4:
                        DeleteCategoryScreen.Load(connection);  
                        break;
                    case 5:
                        Console.WriteLine("ok, Ate mais!...");
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
                Load();
            }

        }
    }
}
