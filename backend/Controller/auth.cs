using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Model;



[ApiController]

public class Auth : ControllerBase
{

    public readonly Userservice taskservice;
    public Auth(Userservice taskservice)
    {
        this.taskservice = taskservice;
    }

    [HttpPost("api/login")]
    public IActionResult login([FromBody] UserLoginRequest login)
    {


        var response = taskservice.login(login);

        return Ok(response);

    }

    [HttpPut("api/addpoints")]
    public IActionResult login(string userid, double points)
    {


        var response = taskservice.updatepoints(userid, points);

        return Ok(response);

    }

    [HttpGet("api/ranking")]
    public IActionResult ranking()
    {


        var response = taskservice.Rankings();

        return Ok(response);

    }

    [HttpPost("api/profile")]
    public IActionResult Profile([FromBody] string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            return BadRequest("Username is required.");
        }

        var user = taskservice.GetUserByUsername(username);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        return Ok(user);
    }


    [HttpPost("api/register")]
    public IActionResult register([FromBody] PublicUser login)
    {

        var user = new privateUser
        {
            userid = Guid.NewGuid().ToString(),
            username = login.username,
            email = login.email,
            password = login.password,
            cities = login.cities,
            point = 0,

        };

        var response = taskservice.register(user);

        return Ok(response);

    }

    [HttpGet("api/home")]
    public IActionResult home()
    {

        return Ok("sucessful");
    }

    [HttpGet("/googlelogin")]

    public IActionResult googlsingnin()
    {

        var prop = new AuthenticationProperties
        {
            RedirectUri = "api/home"
        };

        return Challenge(prop, "Google");

    }



}