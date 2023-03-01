using Microsoft.AspNetCore.Mvc;
using CreateUserTestAPI.Model;
using CreateUserTestAPI.Data;

namespace CreateUserTestAPI.Controllers
{
    [Route("api/CreateUserTestAPI")]
    [ApiController]
    public class CreateUserController : ControllerBase
    {
        private readonly ILogger<CreateUserController> _logger;
        private readonly ApplicationDBContext _dbContext;

        public CreateUserController(ILogger<CreateUserController> logger, ApplicationDBContext db) 
        { 
            _logger = logger;
            _dbContext = db;
        }

        // get method to return all users and test the api
        // functionality not requested so could be removed in future
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User{FirstName="Bob", LastName="Jones", DateOfBirth=new DateTime(22/09/1989), Address="4 Road, Raumati"}
            };
        }


        // post method to create a new user
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> CreateUser([FromBody]User user)
        {

            // check if this user exists already 
          /*  if (_dbContext.Users.FirstOrDefault(u => u.FirstName == "Bob"))
            {
                return BadRequest("User alread exists");
            }*/

         // returns BadRequest for null user
            if (user == null)
            {
                _logger.LogError("Create User Error - user is null");
                return BadRequest(user);
            }

            // UPDATE: add further validation 

            // returns OK and the user if passess validation
            // UPDATE: store user
            _dbContext.Add(user);
            _dbContext.SaveChanges();

            _logger.LogInformation("Created User " + user.FirstName);
            return Ok(user);
        }
    }
}
