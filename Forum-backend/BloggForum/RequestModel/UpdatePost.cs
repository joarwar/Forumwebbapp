using System.ComponentModel.DataAnnotations;
using Forum.Entities;

namespace Forum.RequestModel
{
    public class UpdatePost
    {

        public int Id { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Content { get; set; }

        public String ImageUrl { get; set; }
        public User User { get; set; }


    }
}
