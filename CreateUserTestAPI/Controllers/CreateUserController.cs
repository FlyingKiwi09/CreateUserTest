using Microsoft.AspNetCore.Mvc;
using CreateUserTestAPI.Model;

namespace CreateUserTestAPI.Controllers
{
    [Route("api/CreateUserTestAPI")]
    [ApiController]
    public class CreateUserController : ControllerBase
    {

        // get method to return all users and test the api
        // functionality not requested and could be removed in future
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User{FirstName="Bob", LastName="Jones", DateOfBirth=new DateTime(22/09/1989), Address="4 Road, Raumati"}
            };
        }

        
    }
}
