using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.ReportScreens
{
    public class ListReportTagPostScreen
    {
        public static void Lista(SqlConnection connection)
        {

            try

            {
                var query = @"SELECT
                                [Tag].*,
                                COUNT([Post].[Id]) AS [Quantidade de Post]
                            FROM   
                                [Tag]
                            LEFT JOIN 
                                [PostTag] on [PostTag].[TagId] = [Tag].[Id]
                            LEFT JOIN 
                                [Post] on [Post].Id = [PostTag].[PostId]
                            WHERE
                                [Post].Id IS NOT NULL
                            GROUP BY
                                Tag.Id,
                                Tag.Name,
                                Tag.Slug,
                                Post.Id";

                var tagPots = connection.Query<object>(query);


                Console.WriteLine();
                Console.WriteLine("----------------------------------------Lista de Tags e sua  quantidade de Posts----------------------------------------");
                Console.WriteLine();

                foreach (var tagspost in tagPots)

                {

                    Console.WriteLine(tagspost.ToString().Replace("{DapperRow,", "").Replace("'", "").Replace("}", ""));

                }
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

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

