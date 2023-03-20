using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTestTask.Model;

namespace RazorTestTask.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public FormRegistrationUser user { get; set; } = new();

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            if(TryValidateModel(user, nameof(user))){
                
                using(ApplicationDateBase db = new ApplicationDateBase())
                {
                    db.Users.Add(new User { Name = user.Name, Subname = user.Subname, Login = user.Login, Password = user.Password, Role = db.Roles.Where(u => u.Name == "User").First() });
                    db.SaveChanges();
                }

                return RedirectToPage("Index");
            }
            return null;
        }
    }
}
