using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowman.Tourism.WebApi.Dto
{
    public class SpotDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public CategoryDto Category { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<PictureDto> Pictures { get; set; }
    }
}
