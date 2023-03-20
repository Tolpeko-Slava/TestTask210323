using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorTestTask.Model;

namespace RazorTestTask.Pages
{
    public class AdministrationModel : PageModel
    {
        [BindProperty]
        public List<User> users { get; set; } = new List<User>();
        [BindProperty]
        public bool FlagUpdateUser { get; set; } = new();
        [BindProperty]
        public User userOld { get; set; } = new();
        [BindProperty]
        public User userNew { get; set; } = new();

        public void OnGet()
        {
            using(ApplicationDateBase db = new ApplicationDateBase())
            {
                users = db.Users.Include(p => p.Role).ToList();
            }
        }

        public void OnPostUpdate(string Name, string Role)
        {
            string[] name = Name.Split(' ',StringSplitOptions.RemoveEmptyEntries);

            using(ApplicationDateBase db = new ApplicationDateBase())
            {
                User userInDateBase = db.Users.Include(p => p.Role).Where(u => u.Name == name[1] && u.Subname == name[0] && u.Role.Name == Role).First();
                userOld = userInDateBase;
                userNew = userInDateBase;
            }

            FlagUpdateUser = true;
            OnGet();
        }

        public void OnPostUpdateUser()
        {

            using(ApplicationDateBase db = new ApplicationDateBase())
            {
                var userUpdate = db.Users.Include(s => s.Role).Where(u => u.Name == userOld.Name && u.Subname == userOld.Subname && u.Login == userOld.Login && u.Password == userOld.Password).First();

                userUpdate.Name = userNew.Name;
                userUpdate.Subname = userNew.Subname; 
                userUpdate.Login = userNew.Login;
                userUpdate.Password = userNew.Password;
                db.SaveChanges();

            }

            FlagUpdateUser = false;
            OnGet();
        }
    }
}
