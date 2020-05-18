using System.ComponentModel.DataAnnotations;

namespace Snowman.Tourism.WebApi.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
