namespace RefitDemo.API.Models
{
    using DataAnnotationsExtensions;
    using System.ComponentModel.DataAnnotations;

    public class UpdateUser
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Email]
        public string Email { get; set; }
    }
}
