using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Entities;

public class Forumpost
{

    [Required]
    [Key]
    public int Id { get; set; } 

    [Required]
    public DateTime TimePosted { get; set; }

    [Required]
    public String Title { get; set; }

    [Required]
    public String Content { get; set; }

    public String ImageUrl { get; set; }

    public int Counter { get; set; }

    public User User { get; set; }

}





 

