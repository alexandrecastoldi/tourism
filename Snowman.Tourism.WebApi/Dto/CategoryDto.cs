using System.ComponentModel.DataAnnotations;

namespace Snowman.Tourism.WebApi.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 100 characters")]
        public string Description { get; set; }

    }
}
