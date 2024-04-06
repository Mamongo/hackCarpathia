using Microsoft.Extensions.Options;
using MongoDB.Driver;
using service;


public class Userservice
{
    private readonly ConnectionStrings _connect;
    public Userservice(IOptions<ConnectionStrings> connect)
    {
        _connect = connect.Value;
    }
    

    
    string database = "User";
    private const string colloctionname = "Users";


    public IMongoCollection<T> mongoCollection<T>(in string collection)
        {
            var connect = new MongoClient(_connect.MongoDbConnectionString);
            var db = connect.GetDatabase(database);
            return db.GetCollection<T>(collection);

        }


       public string login(){

        throw new NotImplementedException();

       }

       
       public string register(){

        throw new NotImplementedException();

       }


       public string Rankings(){

        throw new NotImplementedException();

       }

       public string cityRankings(){

        throw new NotImplementedException();

       }


}