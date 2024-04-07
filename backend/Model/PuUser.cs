using Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class privateUser{
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? objid{ get; set;}
    public string? userid{get;set;}

    public string? username{get;set;}
    public string? email{get;set;}

    public string? password{get;set;}

    public string? cities{get;set;}

    public double point{get;set;}

}


public class PublicUser{
    public string? username{get;set;}

    public string? email{get;set;}

    public string? password{get;set;}

    public string? cities{get;set;}


}