using System.ComponentModel.DataAnnotations;

namespace RazorTestTask.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Role? Role { get; set; }
    }
}
