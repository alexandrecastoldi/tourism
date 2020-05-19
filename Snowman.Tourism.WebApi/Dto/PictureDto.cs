using System.ComponentModel.DataAnnotations;

namespace Snowman.Tourism.WebApi.Dto
{
    public class PictureDto
    {
        public int Id { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public int UserId { get; set; }
    }
}
