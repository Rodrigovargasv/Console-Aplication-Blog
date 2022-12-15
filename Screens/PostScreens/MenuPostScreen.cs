using Blog.ConnectionDataBase;
using Blog.Screens.RoleScreens;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.PostScreens
{
    public static class MenuPostScreen
    {
        public static void Load()
        {
            try
            {
                var connection = new SqlConnection(DataBase._connectionDataBase);

                Console.Clear();
                Console.WriteLine("Gestão de Post");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Digite a opção a baixo que deseja realizar:");
                Console.WriteLine();
                Console.WriteLine("1 - Listar Post");
                Console.WriteLine("2 - Cadastrar Post");
                Console.WriteLine("3 - Atualiza Post");
                Console.WriteLine("4 - Deletar Post");
                Console.WriteLine("5 - Sair");

                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                var option = short.Parse(Console.ReadLine());

                Console.Clear();
                switch (option)
                {
                    case 1:
                        ListPostScreen.Lista(connection);
                        ListPostScreen.Load();
                        break;
                    case 2:
                        CreatePostScreen.Load(connection);
                        break;
                    case 3:
                        UpdatePostScreen.Load(connection);
                        break;

                    case 4:
                        DeletePostScreen.Load(connection);
                        break;
                    case 5:
                        Console.WriteLine("Ate mais!..");
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
