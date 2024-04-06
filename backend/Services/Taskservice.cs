using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace service;

public class Taskservice 
{

    private readonly ConnectionStrings _connect;

    public Taskservice(IOptions<ConnectionStrings> connect)
    {
        _connect = connect.Value;
    }

    string database = "Taskdb";
    private const string colloctionname = "Task";


    public IMongoCollection<T> mongoCollection<T>(in string collection)
        {
            var connect = new MongoClient(_connect.MongoDbConnectionString);
            var db = connect.GetDatabase(database);
            return db.GetCollection<T>(collection);

        }

    public List<Tasks> GetTasks()
    {
       var connect = mongoCollection<Tasks>(colloctionname);

       return connect.Find(x=>true).ToList();

    }

    public string MakeTask(Tasks task){

        var connect = mongoCollection<Tasks>(colloctionname);

        connect.InsertOne(task);

        return "success";

    }


}

