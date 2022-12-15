using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{

    // A classe repository sera do tipo generica chamada Tmodel, onde o ele so iria aceita a criação ...
    // de repository se o tipo Tmodel generico for do tipo classe.
    public class Repository<TModel> where TModel : class
    {
        // fazendo conexão com banco de dados
        private readonly SqlConnection _connection;


        // construtor
        public Repository(SqlConnection connection)

           => _connection = connection;

        public Repository()
        {
        }


        // buscando uma lista de model
        public IEnumerable<TModel> Get()
            // metado get all traz todos os dados de model
            => _connection.GetAll<TModel>();


        // buscando model pelo Id
        public TModel GetId(int id)

            // busca o model pelo Id
            => _connection.Get<TModel>(id);



        // criando um novo role no base de dados
        public void Create(TModel model)
        
            // faz um insert no banco de dados
           => _connection.Insert<TModel>(model);
        

        // Fazendo um update de model
        public void Update(TModel model)

               // faz um update no id passado no paramentro model
               => _connection.Update<TModel>(model);


        // Deletando um model
        public void Delete(TModel model)

               // Deleta um model com Id passado no paramento mode
               => _connection.Delete<TModel>(model);


        //sobrecarga de metados, e delete a baixa pode apagar todosdemo
        public void Delete(int id)
        {

            var model = _connection.Get<TModel>(id);

            // Deleta um model com Id passado no paramento model
            _connection.Delete<TModel>(model);

        }
        
    }
}
