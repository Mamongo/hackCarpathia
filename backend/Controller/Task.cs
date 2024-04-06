using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using service;


[ApiController]
public class Tservice:ControllerBase{

    public readonly Taskservice taskservice;

    public Tservice(Taskservice taskservice)
    {
        this.taskservice = taskservice;
    }

    [HttpPost("/task")]

     public IActionResult post([FromBody]PublicTasks task){

    
        var obj = new Tasks{
            id=ObjectId.GenerateNewId().ToString(),
            Title=task.Title,
            companyname=task.companyname,
            description=task.description,
            price=task.price
        };
            
        var response = taskservice.MakeTask(obj);

        return Ok(response);

     }

     [HttpPost("/gettask")]

     public IActionResult get(){

        var response = taskservice.GetTasks();

        return Ok(response);

     }





}

