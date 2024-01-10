using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HandsonAPIUsingModelValidation.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "enter gender")]
        public string Gender {  get; set; }
        [Range(18, 90, ErrorMessage = "age btw 18 and 90")]
        public int Age { get; set; }
        [Required(ErrorMessage = "enter dob")]
        public DateTime Dob {  get; set; }
        [Required(ErrorMessage ="enter email")]
        [EmailAddress(ErrorMessage ="invalid wmailid")]
       
        public string Email { get; set; }
        [Required(ErrorMessage = "enter mobile")]
        [RegularExpression("[6-9]\\d{9}",ErrorMessage = "invalid ")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "enter password")]
        [RegularExpression("[a-zA-Z0-9]{6,8}", ErrorMessage = "invalid ")]
        public string Password { get; set; }
        [Required(ErrorMessage = "enter userName")]
        public string Username { get; set; }
       
    }
}
