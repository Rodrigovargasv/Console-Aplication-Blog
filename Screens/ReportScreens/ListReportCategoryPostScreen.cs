using Dapper;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.ReportScreens
{
    public static class ListReportCategoryPostScreen
    {
        public static void Lista(SqlConnection connection)
        {

            try

            {
                //Traz um liesta de gategoria e a soma poste desra categoria
                var query = @"SELECT
                                [Category].*,
                                COUNT([Post].[CategoryId]) AS [Quantidade de Post]
                            FROM
                                [Category]
                            INNER JOIN 
                                [Post] on [Post].[CategoryId] = [Category].[Id]
                            WHERE 
                                [Post].CategoryId IS NOT NULL
                            GROUP BY
                                [Category].[Id],
                                [Category].[Name],
                                [category].[Slug],
                                [Post].[CategoryId]";



                var categoryPosts = connection.Query<object>(query);

                Console.WriteLine("-----------------------Lista de Categoria e a quantidade de Post-----------------------");
                Console.WriteLine();
                
                foreach (var categoryPost in categoryPosts)

                {

                    Console.WriteLine(categoryPost.ToString().Replace("{DapperRow,", "").Replace("'", "").Replace("}", ""));
                    
                }
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------------------------");

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
