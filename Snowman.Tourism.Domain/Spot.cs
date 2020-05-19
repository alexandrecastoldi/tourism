using Snowman.Tourism.Domain.Identity;
using System.Collections.Generic;

namespace Snowman.Tourism.Domain
{
    public class Spot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string ImageURL { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Picture> Pictures { get; set; }
    }
}
