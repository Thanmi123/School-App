using HandsonAPIUsingModelValidation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsonAPIUsingModelValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//validating the user
    public class AccountController : ControllerBase
    {
        List<Login> logins = new List<Login>()
        {
            new Login(){username="Anna",password="12345"},
            new Login(){username="Faris",password="12345"},
            new Login(){username="Amal",password="12345"},
            new Login(){username="Arjun",password="12345"},
        };
        List<User> users = new List<User>() 
        { 
            new User(){Id=2000,Name="anna",Username="Anna",Password="12345",Email="aaaa@gmail.com",Mobile="4485996673"}
        };
        
        public IActionResult Validate(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var user=logins.SingleOrDefault(u=>u.username==login.username&&u.password==login.password)
                    /*var user = (from u in logins
                                where u.username == login.username && u.password == login.password
                                select u).SingleOrDefault();*/
                    var user = (from l in logins
                                join u in users
                                on l.username equals u.Username
                                where u.Username == login.username && u.Password == login.password
                                select u).SingleOrDefault();

                    if (user != null)
                    {
                        //return StatusCode(200, new JsonResult("Valid user"));
                        return StatusCode(200, user);


                    }
                    else
                    {
                        return StatusCode(200, new JsonResult("Invalid user"));
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost, Route("Register")]
        public IActionResult Register([FromBody]User user)
            
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Id = new Random().Next();
                    //add mdel to the backend table
                    users.Add(user);
                    return Ok(user);//ok request returns model data with status code 200
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(501,ex);
            }
        }
    }
}
