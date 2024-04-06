using Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Tasks{


    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id{get;set;}
    public string? companyname{get;set;}
    public string? Title{get;set;}
    public string? description{get;set;}
    public string? price{get;set;}


}

public class PublicTasks
{
    public string? companyname{get;set;}
    public string? Title{get;set;}
    public string? description{get;set;}
    public string? price{get;set;}

}