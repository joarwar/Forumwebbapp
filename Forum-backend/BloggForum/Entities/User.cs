using System.ComponentModel.DataAnnotations;

namespace Forum.Entities;

public class User
{
    [Required]
    public int Id { get; set; }

    [Required]
    public String Username  { get; set; }

    [Required]
    
    public String Password { get; set; }
    
    List<Forumpost> Forumposts { get; set; }  

}







