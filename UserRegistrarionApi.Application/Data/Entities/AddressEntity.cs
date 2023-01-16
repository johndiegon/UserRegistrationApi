using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistrationApi.Application.Data.Repositories
{
    [Table("POC_Address")]
    public class AddressEntity
    {
        [Key]
        [Required(ErrorMessage = "Enter AddresEntity ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter User ID")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter Country")]
        public string Country { get; set; }

        public string Country_code { get; set; }

        [Required(ErrorMessage = "Enter State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Enter Street")]
        public string Street { get; set; }

        public string Type { get; set; }

        [Required(ErrorMessage = "Enter ZipCode")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Enter Number")]
        public string Number { get; set; }
        public string Complement { get; set; }
    }

}
