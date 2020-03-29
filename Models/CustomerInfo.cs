using System.ComponentModel.DataAnnotations;

namespace RazorPagesContacts.Models
{
    public class CustomerInfo
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string State { get; set; }
    }
}