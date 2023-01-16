using UserRegistrationApi.Application.Enuns;

namespace UserRegistrationApi.Application.Model
{
    public class User
    {
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public int Age
        {
            get { return  DateTime.Now.Year - this.DateBirth.Year; }
        }
        public Gender Gender { get; set; }  
        public DocumentType DocumentType { get; set; }
        public Dictionary<ContactType,string>  Contacts { get; set; } 
        public Address Address { get; set; }    
    }
}
