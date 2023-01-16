using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistrationApi.Application.Data.Repositories
{
    [Table("POC_User")]
    public class UserEntity
    {
        [Key]
        [Required(ErrorMessage = "Enter User ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter User Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter User DateBirth")]
        public DateTime DateBirth { get; set; }

        [Required(ErrorMessage = "Enter User Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter Document Type")]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "Enter Document")]
        public string Document { get; set; }
    }
}
