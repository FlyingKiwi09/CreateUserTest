using System.ComponentModel.DataAnnotations;

namespace CreateUserTestAPI.Model
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        //attributes work with '[ApiController]' attribute in the controller class to validate user data in requests
        [Required]
        [MaxLength(30)]
        public String FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public String LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(100)]
        public String Address { get; set; }
    }
}
