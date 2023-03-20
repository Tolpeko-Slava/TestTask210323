using System.ComponentModel.DataAnnotations;

namespace RazorTestTask.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0,2000000)]
        public int Quantity { get; set; }

    }
}
