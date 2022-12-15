using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.ReportScreens
{
    public static class ListReportPostsCategorysScreen
    {
        public static void Lista(SqlConnection connection)
        {

            try

            {

                var query = @"SELECT
                                [Post].*,
                                [Category].*
    
                            FROM
                                [Post]
                            LEFT JOIN [Category] on [Category].[Id] = [Post].[CategoryId]
                            WHERE [Post].CategoryId IS NOT NULL;";


                var categorysPosts = connection.Query<object>(query);

                Console.WriteLine("----------------------------------------------------------------Lista de Posts e Categorias----------------------------------------------------------------");
                Console.WriteLine();

                foreach (var categoryPost in categorysPosts)

                {

                    Console.WriteLine(categoryPost.ToString().Replace("{DapperRow,", "").Replace("'", "").Replace("}", ""));
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

