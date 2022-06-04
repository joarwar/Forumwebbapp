using System.ComponentModel.DataAnnotations;

namespace Forum.RequestModel
{
    public class DeletePostRequest
    {
        [Required]
        public int Id { get; set; }

    }
}
