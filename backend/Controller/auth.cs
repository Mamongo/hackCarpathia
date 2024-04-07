using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Model;



[ApiController]

public class Auth:ControllerBase{

    [HttpPost("api/login")]
    public IActionResult login([FromBody] UserLoginRequest login){

        return Ok("sucessful");
    }

     [HttpGet("api/home")]
    public IActionResult home(){

        return Ok("sucessful");
    }

    [HttpGet("/googlelogin")]

    public IActionResult googlsingnin(){

        var prop = new AuthenticationProperties{
                RedirectUri="api/home"
            };

        return Challenge(prop,"Google");

    }

       
  
}