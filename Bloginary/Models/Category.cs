using System.ComponentModel.DataAnnotations.Schema;

namespace Bloginary.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public int? BlogId { get; set; }
        [ForeignKey("BlogId")]
        public Blog? Blog { get; set; }
    }
}
