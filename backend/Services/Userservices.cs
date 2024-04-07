using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Options;
using Model;
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
        var connect = new MongoClient("mongodb+srv://alnurmadiyev:td7FV5230wHdAwfv@hackaton.kgrkzyk.mongodb.net/?retryWrites=true&w=majority&appName=hackaton");
        var db = connect.GetDatabase(database);
        return db.GetCollection<T>(collection);

    }


    public string login(UserLoginRequest login)
    {

        var connect = mongoCollection<privateUser>(colloctionname);

        var usern = Builders<privateUser>.Filter.Eq(x => x.username, login.Username);
        var pass = Builders<privateUser>.Filter.Eq(x => x.password, login.Password);

        var filter = Builders<privateUser>.Filter.And(usern, pass);

        //
        var exist = connect.Find(filter).FirstOrDefault();

        if (exist != null)
        {

            return "success";
        }
        else
        {
            throw new Exception("username or password wrong");
        }

    }


    public string register(privateUser privateUser)
    {

        var connect = mongoCollection<privateUser>(colloctionname);

        var exist = connect.Find(u => u.username == privateUser.username && u.password == privateUser.password).FirstOrDefault();

        if (exist != null)
        {

            throw new Exception(" user already exist");

        };

        connect.InsertOne(privateUser);

        return "success";

    }


    public List<Returnuser> Rankings()
    {

        var connect = mongoCollection<privateUser>(colloctionname);
        var sort = Builders<privateUser>.Sort.Descending(u => u.point);

        var response = connect.Find(x => true).Sort(sort).Limit(15).ToList();

        return response.Select(u => new Returnuser
        {
            username = u.username,
            points = u.point
        }).ToList();

    }

    public privateUser GetUserByUsername(string username)
    {
        var connect = mongoCollection<privateUser>(colloctionname);

        var filter = Builders<privateUser>.Filter.Eq(u => u.username, username);

        var user = connect.Find(filter).FirstOrDefault();

        return user;
    }


    public string cityRankings()
    {

        throw new NotImplementedException();

    }

    public string updatepoints(string userId, double pointsToAdd)
    {

        var connect = mongoCollection<privateUser>(colloctionname);

        var filter = Builders<privateUser>.Filter.Eq(u => u.userid, userId);
        var update = Builders<privateUser>.Update.Inc(u => u.point, pointsToAdd);

        connect.UpdateOne(filter, update);

        return "sucessful";

    }

    //    public Dictionary<string, double> CityRankings()
    // {
    //     var collection = mongoCollection<privateUser>(colloctionname); 

    //     var cityRankings = collection.AsQueryable()
    //         .GroupBy(u => u.cities)
    //         .Select(g => new
    //         {
    //             City = g.Key,
    //             TotalPoints = g.Sum(u => u.point)
    //         })
    //         .ToDictionary(x => x.City, x => x.TotalPoints);

    //     return cityRankings;
    // }


}