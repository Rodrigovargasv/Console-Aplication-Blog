using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.ReportScreens
{
    public static class ListReportPostTagScreen
    {
        public static void Lista(SqlConnection connection)
        {

            try

            {


                var query = @"SELECT 
                                [Post].*,
                                [Tag].*
                             FROM
                                [Post] 
                            LEFT JOIN 
                                [PostTag] on [PostTag].[PostId] = [Post].[Id]
                            LEFT JOIN  
                                [Tag] on [Tag].[Id] = [PostTag].[TagId]
                            WHERE [PostTag].[TagId] IS NOT NULL";

                var postsTags = connection.Query<object>(query);


                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------------Lista de Posts e de Tags-----------------------------------------------------------------");
                Console.WriteLine();

                foreach (var postTag in postsTags)

                {

                    Console.WriteLine(postTag.ToString().Replace("{DapperRow,", "").Replace("'", "").Replace("}", ""));
                    Console.WriteLine();

                }
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");

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

