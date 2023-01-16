using UserRegistrationApi.Application.Enuns;
using UserRegistrationApi.Application.Model;
using UserRegistrationApi.Application.Validator;

namespace UserRegistrationApi.Application.Contract.Request
{
    public class UserRequest : Validate
    {
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public Gender Gender { get; set; }
        public DocumentType DocumentType { get; set; }
        public string  Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cep { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new UserRequestValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
