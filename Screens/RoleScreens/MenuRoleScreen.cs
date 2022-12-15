using Blog.ConnectionDataBase;
using Blog.Screens.UserScreens;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.RoleScreens
{
    public static class MenuRoleScreen
    {
        public static void Load()
        {
            try
            {
                var connection = new SqlConnection(DataBase._connectionDataBase);

                Console.Clear();
                Console.WriteLine("Gestão de Perfil");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Digite a opção a baixo que deseja realizar:");
                Console.WriteLine();
                Console.WriteLine("1 - Listar Role");
                Console.WriteLine("2 - Cadastrar Role");
                Console.WriteLine("3 - Atualiza Role");
                Console.WriteLine("4 - Deletar Role");
                Console.WriteLine("5 - Sair");

                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                var option = short.Parse(Console.ReadLine());

                Console.Clear();
                switch (option)
                {
                    case 1:
                        ListRoleScreen.Lista(connection);
                        ListRoleScreen.Load();
                        break;
                    case 2:
                        CreateRoleScreen.Load(connection);
                        break;
                    case 3:
                        UpdateRoleScreen.Load(connection); 
                        break;

                    case 4:
                        DeleteRoleScreen.Load(connection);
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
