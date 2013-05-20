using System.ComponentModel.DataAnnotations;

namespace Blog.DAL.Model
{
    public class Comments
    {
        [Key]
        public long PostId { get; set; }

        public string Content { get; set; }
    }
}