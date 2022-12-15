using Blog.ConnectionDataBase;
using Blog.Models;
using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;
using System;
using Blog.Repositories;
using System.Data;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Blog.Screens.RoleScreens;
using Blog.Screens.CategoryScreens;
using Blog.Screens.PostScreens;
using Blog.Screens.UserRoleScreens;
using Blog.Screens.PostTagScreens;
using Blog.Screens.ReportScreens;

namespace Blog
{
    public class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection(DataBase._connectionDataBase);

            connection.Open();
            LoadMenuSystem();
          
            connection.Close();
            Console.ReadKey();

        }

        private static void LoadMenuSystem()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Qual opção a baixo deseja fazer: ");
                Console.WriteLine();
                Console.WriteLine("1 - Gestão de usuario");
                Console.WriteLine("2 - Gestão de perfil");
                Console.WriteLine("3 - Gestão de categoria");
                Console.WriteLine("4 - Gestão de tag");
                Console.WriteLine("5 - Gestao de post");
                Console.WriteLine("6 - Vincular perfil/Usuario");
                Console.WriteLine("7 - Vincular post/tag");
                Console.WriteLine("8 - Relatorios");
                Console.WriteLine("9 - Sair");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                var option = short.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        MenuUserScreen.Load();
                        break;
                    case 2:
                        MenuRoleScreen.Load();
                        break;
                    case 3:
                        MenuCategoryScreen.Load();
                        break;

                    case 4:
                        MenuTagScreen.Load();
                        break;
                    case 5:
                        MenuPostScreen.Load();
                        break;
                    case 6:
                        MenuUserRoleScreen.Load();
                        break;
                    case 7:
                        MenuPostTagScreen.Load();
                        break;

                    case 8:
                        MenuReportScreen.Load();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção invalida aperte qualquer tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        LoadMenuSystem();
                        break;
                }
            }
            catch(Exception ex) 
            {
                Console.Clear();
                Console.WriteLine("Erro: " + ex.Message);
                Console.WriteLine("Aperte qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                LoadMenuSystem();
            }
        }

        
    }
}