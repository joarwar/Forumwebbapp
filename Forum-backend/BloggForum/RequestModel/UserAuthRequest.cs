using System.ComponentModel.DataAnnotations;

namespace Forum.RequestModel
{
    public class UserAuthRequest
    {
        
        [Required]
        public String Username { get; set; }

        [Required]
        public String Password { get; set; }
    }
}
