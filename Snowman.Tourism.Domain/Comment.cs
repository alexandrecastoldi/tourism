using Snowman.Tourism.Domain.Identity;

namespace Snowman.Tourism.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int SpotId { get; set; }
        public int UserId { get; set; }
        public Spot Spot { get; set; }
        public User User { get; set; }
    }
}