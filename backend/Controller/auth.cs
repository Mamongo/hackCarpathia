using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Model;

[ApiController]
[Route("/[controller]")]
public class AuthController:ControllerBase{

    [HttpPost("/login")]
    public IActionResult login([FromBody] UserLoginRequest login){

        return Ok("sucessful");
    }

    [HttpGet("/googlelogin")]

    public IActionResult googlsingnin(){

        return Ok("sucessful");
        
    }

       
  
}