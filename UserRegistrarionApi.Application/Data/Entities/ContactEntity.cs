using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistrationApi.Application.Data.Repositories
{
    [Table("POC_Contact")]
    public class ContactEntity
    {
        [Key]
        [Required(ErrorMessage = "Enter Contact ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter User ID")]
        public int UserId { get; set; }

        [Key]
        [Required(ErrorMessage = "Enter Contact Type")]
        public string ContactType { get; set; }

        [Key]
        [Required(ErrorMessage = "Enter Contact")]
        public string Contact { get; set; }
    }
}
