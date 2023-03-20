using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorTestTask.Model;

namespace RazorTestTask.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Product> products { get; set; } = new List<Product>();
        [BindProperty]
        public Product productInf { get; set; } = new();
        [BindProperty]
        public Product productOld { get; set; } = new();
        [BindProperty]
        public FormUser user { get; set; } = new();

        [BindProperty]
        public string userInSite { get; set; } = "Guest";
        [BindProperty]
        public bool FlagUpdateProduct { get; set; } = new();

        public void OnGet()
        {
            ReadProducts();
        }

        public void ReadProducts()
        {
            using(ApplicationDateBase db = new ApplicationDateBase())
            {
                products.AddRange(db.Products);
            }
        }

        public ActionResult OnPostAddProduct()
        {
            if (IsValidationProduct(productInf))
            {
                using (ApplicationDateBase db = new ApplicationDateBase())
                {
                    db.Products.Add(new Product { Name = productInf.Name, Quantity = productInf.Quantity });
                    db.SaveChanges();
                }
                return RedirectToPage("Index");
            }
            return null;
        }

        public ActionResult OnPostDeleteProduct()
        {
            using(ApplicationDateBase db = new ApplicationDateBase())
            {
                db.Products.Remove(new Product { Id = productInf.Id, Name = productInf.Name, Quantity = productInf.Quantity });
                db.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public void OnPostUpdateProduct()
        {
            using(ApplicationDateBase db = new ApplicationDateBase())
            {
                var product = db.Products.Where(s=>s.Name == productOld.Name && s.Quantity == productOld.Quantity).First();

                product.Name = productInf.Name;
                product.Quantity = productInf.Quantity;

                db.SaveChanges();
            }
            OnGet();
        }

        public void OnPostUpdateProductWindow()
        {
            productOld = productInf;

            FlagUpdateProduct = true;
            OnGet();
        }

        public void OnPostJoinUser()
        {
            if (IsValidationUserJoin(user))
            {
                using (ApplicationDateBase db = new ApplicationDateBase())
                {
                    var flag = db.Users.Any(s => s.Login == user.Login && s.Password == user.Password);
                    if (flag)
                    {
                        var userInDateBase = db.Users.Include(p=>p.Role).Where(s => s.Login == user.Login && s.Password == user.Password).FirstOrDefault();
                        if(userInDateBase.Role.Name == "Admin")
                        {
                            userInSite = "Admin";
                        }
                        else
                        {
                            userInSite = "User";
                        }
                    }
                }
            }
            OnGet();
        }

        private bool IsValidationProduct(Product product)
        {
            if (product.Name != null && product.Quantity > 0 && product.Quantity < 2000000) 
            {
                return true;
            }

            return false;
        }

        private bool IsValidationUserJoin(FormUser user)
        {
            if (user.Login != null && user.Password != null)
            {
                return true;
            }

            return false;
        }
    }
}
