using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;
using Dapper;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.ReportScreens
{
    public static class ListReportUserRoleScreen
    {

        public static void Lista(SqlConnection connection)
        {

            try

            {

               
                var query = @"SELECT 
                                [User].[Name] as [Name do usuario],
                                [User].Email,
                                [Role].*
                              FROM
                                [User] 
                              LEFT JOIN 
                                [UserRole] on [UserRole].[UserId] = [User].[Id]
                              LEFT JOIN  
                                [Role] on [UserRole].[RoleId] = [Role].Id 
                              WHERE [Role].Id IS NOT NULL";

                var postsTags = connection.Query<object>(query);
               

                Console.WriteLine();
                Console.WriteLine("----------------------------------------Lista de Posts e seus Perfils----------------------------------------");
                Console.WriteLine();

                foreach (var postTag in postsTags)

                {
                    
                    Console.WriteLine(postTag.ToString().Replace("{DapperRow,", "").Replace("'", "").Replace("}", ""));

                }
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

                Console.WriteLine();
                Console.ReadKey();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                Console.ReadKey();
                MenuReportScreen.Load();
            }
        }

        public static void Load()
        {
            Console.ReadKey();
           
            MenuReportScreen.Load();
        }
    }
}


