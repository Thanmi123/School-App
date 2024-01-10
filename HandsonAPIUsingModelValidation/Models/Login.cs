using System.ComponentModel.DataAnnotations;

namespace HandsonAPIUsingModelValidation.Models
{
    public class Login
    {
        [Required(ErrorMessage ="pls enter the usename")]
        public string username { get; set; }
        [Required(ErrorMessage = "pls enter the password")]
        public string password { get; set; }
    }
}
