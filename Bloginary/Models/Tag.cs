using System.ComponentModel.DataAnnotations.Schema;

namespace Bloginary.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public required string TagName { get; set; }

        public int? BlogId { get; set; }
        [ForeignKey("BlogId")]
        public Blog? Blog { get; set; }
    }
}
