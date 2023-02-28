using Microsoft.AspNetCore.Mvc;
using CreateUserTestAPI.Model;

namespace CreateUserTestAPI.Controllers
{
    [Route("api/CreateUserTestAPI")]
    [ApiController]
    public class CreateUserController : ControllerBase
    {
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
         // returns BadRequest for null user
            if (user == null)
            {
                return BadRequest(user);
            } 

        // checks each of the fields in user and returns BadRequest with error message if one of them is null
            // UPDATE: could be updated to check all fields and return appropriate error messages if multiple fields are missing
            if (string.IsNullOrEmpty(user.FirstName))
            {
                return BadRequest("FirstName cannot be null");
            }
            if (string.IsNullOrEmpty(user.LastName)) 
            {
                return BadRequest("LastName cannot be null");
            }

            // UPDATE: is expecting a DateTime object in the request - could be updated to expect a string in a DTO but store a DateTime object in the User/DB
            try
            {
                DateTime dateOfBirth = Convert.ToDateTime(user.DateOfBirth); 
            } catch 
            {
                return BadRequest("Date of birth must be in the format dd/mm/yyyy");
            }

            if (string.IsNullOrEmpty(user.Address))
            {
                return BadRequest("Address cannot be null");
            }

            // UPDATE: add further validation 

        // returns OK and the user if passess validation
            // UPDATE: store user
            return Ok(user);
        }
    }
}
