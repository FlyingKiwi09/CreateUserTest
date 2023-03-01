using System.ComponentModel.DataAnnotations;

namespace CreateUserTestAPI.Model
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        //attributes work with '[ApiController]' attribute in the controller class to validate user data in requests
        [Required(ErrorMessage = "First name is requred")]
        [MaxLength(30)]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is requred")]
        [MaxLength(30)]
        public String LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is requred")]
        [MaxLength(100)]
        public String Address { get; set; }
    }
}
