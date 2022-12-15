using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using System;


namespace Blog.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        // criando um novo usuario no base de dados
        public static void Load(SqlConnection connection)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.Write("Digite a quantidade de Tag que deseja cadastrar: ");
                var quantidadeTags = int.Parse(Console.ReadLine());

                for (var i = 0; i < quantidadeTags; i++)
                {
                    Console.Write("digite um nome da tag: ");
                    var name = Console.ReadLine();

                    Console.Write("Digite o slug da tag: ");
                    var slug = Console.ReadLine();

                    var tag = new Tag()
                    {
                        Name = name,
                        Slug = slug
                    };


                    var repository = new Repository<Tag>(connection);
                    repository.Create(tag);

                    Console.WriteLine();
                    Console.WriteLine("Cadastrado realizado com sucesso!");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                    Console.ReadKey();

                    MenuTagScreen.Load();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            finally { connection.Close(); }
        }
    }
}
