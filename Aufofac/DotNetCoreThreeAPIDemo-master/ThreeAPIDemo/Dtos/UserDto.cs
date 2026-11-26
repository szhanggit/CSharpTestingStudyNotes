using System.ComponentModel.DataAnnotations;

namespace ThreeAPIDemo.Dtos
{
    public class UserDto
    {
        [Required]
        public string  Name { get; set; }

        [Required]
        public string  Email { get; set; }
        
    }
}