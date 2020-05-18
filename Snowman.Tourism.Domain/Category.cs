using System.Collections.Generic;

namespace Snowman.Tourism.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Spot> Spots { get; set; }
    }
}