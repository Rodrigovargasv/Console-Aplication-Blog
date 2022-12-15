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
    public static class ListCategoryScreen
    {
        public static void Lista(SqlConnection connection)
        {

            try
            {
                var repository = new Repository<Category>(connection);

                var categorys = repository.Get();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                 Lista de Categoria                   ");

                foreach (var category in categorys)
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine();
                    Console.Write($"Id: {category.Id} " +
                        $"Nome: {category.Name} " +
                        $"Slug: {category.Slug}");
                    Console.WriteLine();


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                Load();
            }
        }

        public static void Load()
        {
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

    }
}

