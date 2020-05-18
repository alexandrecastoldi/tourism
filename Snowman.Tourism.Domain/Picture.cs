using Snowman.Tourism.Domain.Identity;

namespace Snowman.Tourism.Domain
{
    public class Picture
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public int SpotId { get; set; }
        public int UserId { get; set; }
        public Spot Spot { get; set; }
        public User User { get; set; }
    }
}