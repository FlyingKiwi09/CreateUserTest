using Microsoft.AspNetCore.Mvc;
using CreateUserTestAPI.Model;
using CreateUserTestAPI.Data;
using System.Text.RegularExpressions;

namespace CreateUserTestAPI.Controllers
{
    [Route("api/CreateUserTestAPI")]
    [ApiController]
    public class CreateUserController : ControllerBase
    {
        // logger uses Serilog to write logs to file
        private readonly ILogger<CreateUserController> _logger;
        // connection to SQL database
        private readonly ApplicationDBContext _dbContext;

        public CreateUserController(ILogger<CreateUserController> logger, ApplicationDBContext db) 
        { 
            _logger = logger;
            _dbContext = db;
        }

        // get method to return all users and test the api
        // functionality not requested so could be removed in future
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_dbContext.Users.ToList());
        }


        // post method to create a new user
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> CreateUser([FromBody]User user)
        {

            // NOTE: validation moved to attributes in data model except for Date of Birth which is still handled here. 


            /*// check if this user exists already 
            if (_dbContext.Users.FirstOrDefault(u => u.FirstName.ToLower() == user.FirstName.ToLower()) != null)
            {
                _logger.LogError("Create User Error - user already exists");
                return BadRequest("User already exists");
            }*/

           /* // validate first name
            if (user.FirstName == null)
            {
                _logger.LogError("Create User Error - first name is null");
                return BadRequest("New user must have a first name");
            }
            else if (Regex.IsMatch(user.FirstName, @"^[a-zA-Z-]+$"))
            {
                _logger.LogError("Create User Error - first name contains numbers or other characters");
                return BadRequest("First name can only cotain letters");
            }

            // validate last name
            if (user.LastName == null)
            {
                _logger.LogError("Create User Error - last name is null");
                return BadRequest("New user must have a last name");
            }
            else if (Regex.IsMatch(user.LastName, @"^[a-zA-Z-]+$"))
            {
                _logger.LogError("Create User Error - last name contains numbers or other characters");
                return BadRequest("Last name can only cotain letters");
            }*/

            // validate date
            if (user.DateOfBirth.Date < new DateTime(1900, 01, 01))
            {
                _logger.LogError("Create User Error - Date is out of range");
                return BadRequest("Date of birth cannot be before 01/01/1900");
            } else if (user.DateOfBirth.Date > DateTime.Now)
            {
                _logger.LogError("Create User Error - Date is out of range");
                return BadRequest("Date of birth cannot be after the todays date");
            }


                /*    // validate address
                    if (user.Address == null)
                    {
                        _logger.LogError("Create User Error - address is null");
                        return BadRequest("New user must have an address");
                    }*/

                // returns BadRequest for null user
                if (user == null)
            {
                _logger.LogError("Create User Error - user is null");
                return BadRequest(user);
            }

            // adds user to the db and returns OK and the user - if passess validation

            
            _dbContext.Add(user);
            _dbContext.SaveChanges();

            _logger.LogInformation("Created User " + user.FirstName);
            return Ok(user);
        }
    }
}
