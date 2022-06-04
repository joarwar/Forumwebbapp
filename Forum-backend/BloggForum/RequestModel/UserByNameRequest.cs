using System.ComponentModel.DataAnnotations;

namespace Forum.RequestModel
{
    public class UserByNameRequest
    {
        [Required]
        public String Username { get; set; }

    }
}
