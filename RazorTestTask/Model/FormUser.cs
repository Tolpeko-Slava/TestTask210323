using System.ComponentModel.DataAnnotations;

namespace RazorTestTask.Model
{
    public class FormUser
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
