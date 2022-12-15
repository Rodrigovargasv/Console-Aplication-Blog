using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.CategoryScreens
{
    public static class CreateCategory
    {
        public static void Load(SqlConnection connection)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.Write("Digite a quantidade de Categoria que deseja cadastrar: ");
                var quantidadeCategory = int.Parse(Console.ReadLine());

                for (var i = 0; i < quantidadeCategory; i++)
                {
                    Console.Write("digite um nome da categoria: ");
                    var name = Console.ReadLine();

                    Console.Write("Digite o slug da categoria: ");
                    var slug = Console.ReadLine();

                    var category = new Category()
                    {
                        Name = name,
                        Slug = slug
                    };


                    var repository = new Repository<Category>(connection);
                    repository.Create(category);

                    Console.WriteLine();
                    Console.WriteLine("Categoria realizado com sucesso!");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                    Console.ReadKey();

                    MenuCategoryScreen.Load();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            finally { connection.Close(); }
        }
    }
}
