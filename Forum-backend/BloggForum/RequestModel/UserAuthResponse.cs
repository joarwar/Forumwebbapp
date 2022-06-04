using System.ComponentModel.DataAnnotations;
namespace Forum.RequestModel
{
    public class UserAuthResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public String Username { get; set; }

        [Required]
        public String Token { get; set; }
    }
}
