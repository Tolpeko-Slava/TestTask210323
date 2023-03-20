using System.ComponentModel.DataAnnotations;

namespace RazorTestTask.Model
{
    public class FormRegistrationUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Subname { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string DoublePassword { get; set; }
    }
}
