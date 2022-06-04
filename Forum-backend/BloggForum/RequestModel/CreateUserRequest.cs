using System.ComponentModel.DataAnnotations;

namespace Forum.RequestModel;

public class CreateUserRequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    public String Username { get; set; }

    [Required]
    public String Password { get; set; }

}
