using System.ComponentModel.DataAnnotations;
using Forum.Entities;

namespace Forum.RequestModel
{
    public class UpdateUser
    {
        [Required]
        public String Username { get; set; }

        [Required]
        public String Password { get; set; }

    }
}
