using Forum.Entities;
using System.ComponentModel.DataAnnotations;

namespace Forum.RequestModel
{
    public class CreatePostRequest
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime TimePosted { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Content { get; set; }

        public User User { get; set; }
    }
}
