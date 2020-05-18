using System.Collections.Generic;

namespace Snowman.Tourism.WebApi.Dto
{
    public class SpotDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public CategoryDto Category { get; }
        public List<CommentDto> Comments { get; set; }
        public List<PictureDto> Pictures { get; set; }
    }
}
