using Blog.ConnectionDataBase;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.TagScreens
{
    public static class MenuTagScreen 
    {
        public static void Load()
        {
            try
            {
                var connection = new SqlConnection(DataBase._connectionDataBase);

                Console.Clear();
                Console.WriteLine("Gestão de tag");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Digite a opção a baixo que deseja realizar:");
                Console.WriteLine();
                Console.WriteLine("1 - Listar tags");
                Console.WriteLine("2 - Cadastrar tags");
                Console.WriteLine("3 - Atualiza tags");
                Console.WriteLine("4 - Deletar tags");
                Console.WriteLine("5 - Sair");

                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                var option = short.Parse(Console.ReadLine());

                Console.Clear();
                switch (option)
                {
                    case 1:
                        ListTagScreen.Lista(connection);
                        ListTagScreen.Load();

                        break;
                    case 2:
                        CreateTagScreen.Load(connection);
                        break;
                    case 3:
                        UpdateTagScreen.Load(connection);
                        break;

                    case 4:
                        DeleteTagScreen.Load(connection);   
                        break;
                    case 5:
                        Console.WriteLine("Ate mais!...");
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
                Console.WriteLine("Erro: " + ex.Message);
                Load();
            }
            
        }
    }
}
