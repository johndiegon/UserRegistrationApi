using UserRegistrationApi.Application.Contract.Request;
using UserRegistrationApi.Application.Contract.Response;
using UserRegistrationApi.Application.Data;
using UserRegistrationApi.Application.Data.Repositories;
using UserRegistrationApi.Application.Enuns;
using UserRegistrationApi.Application.Helper;
using UserRegistrationApi.Application.Interfaces;

namespace UserRegistrationApi.Application.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<UserResponse> CreateUser(UserRequest user)
        {
            try
            {
                if (user.IsValid())
                {
                    var userId = 0;

                    var entity = new UserEntity
                    {
                        DateBirth = user.DateBirth,
                        Document = user.Document,
                        DocumentType = user.DocumentType.ToString(),
                        Gender = user.Gender.ToString(),
                        Name = user.Name
                    };

                    using (_db)
                    {
                        _db.User.Add(entity);
                        _db.SaveChanges();
                        userId = entity.Id;
                    }

                    var contacts = new List<ContactEntity>();

                    contacts.Add(new ContactEntity
                    {
                        Contact = user.Email,
                        ContactType = ContactType.Email.ToString(),
                        Id = userId
                    });

                    contacts.Add(new ContactEntity
                    {
                        Contact = user.Phone.ToBrazilFormatPhone(),
                        ContactType = ContactType.Phone.ToString(),
                        Id = userId
                    });

                    using (_db)
                    {
                        _db.Contact.AddRange(contacts);
                        _db.SaveChanges();
                    }

                    return UserResponseOk("User Created with Success");
                }
                else
                {
                    var response = UserResponseError("The request is invalid.");
                    response.Notification = user.Notifications();
                    return response;
                }
            } catch (Exception ex)
            {
                return UserResponseError(ex.Message);
            }
        }

        public async Task<UserResponse> DeleteUser(string document)
        {
            try
            {
                using (_db)
                {
                    var user = _db.User.Where(x => x.Document == document).FirstOrDefault();
                    
                    if(user != null)
                    {
                        _db.User.Remove(user);
                        _db.SaveChanges();
                    }
                }

                  
                return UserResponseOk("User deleted with success;");
            }
            catch (Exception ex)
            {
                return UserResponseError(ex.Message);
            }
        }

        public async Task<UserResponse> GetUser(string document)
        {
            try
            {
                UserEntity user;

                using (_db)
                {
                    user = _db.User.Where(x => x.Document == document).FirstOrDefault();
                }

                if (user != null)
                {
                    var response = UserResponseOk("User seached with success");
                    response.User = new Model.User
                    {
                        DateBirth = user.DateBirth,
                        //DocumentType = Enum. user.DocumentType,
                        //Gender = user.Gender,
                        Name = user.Name,
                    };

                    return response;
                }
                else
                {
                    return UserResponseOk("User seached with success"); 
                }
            }
            catch (Exception ex)
            {
                return UserResponseError(ex.Message);
            }
        }

        public async Task<UserResponse> UpdateUser(UserRequest user)
        {
            try
            {
              
                if (user.IsValid())
                {
                    var userEntity = _db.User.Where(x => x.Document == user.Document).FirstOrDefault();
                   
                    if (userEntity == null)
                        return UserResponseError("This user there are not exists in our database");


                    userEntity.DateBirth = user.DateBirth;
                    userEntity.Document = user.Document;
                    userEntity.DocumentType = user.DocumentType.ToString();
                    userEntity.Gender = user.Gender.ToString();
                    userEntity.Name = user.Name;

                    using (_db)
                    {
                        _db.User.Update(userEntity);
                        _db.SaveChanges();
                    }

                    var contactEmail = _db.Contact.Where(x => x.UserId == userEntity.Id 
                                                           && x.ContactType == ContactType.Email.ToString()).FirstOrDefault();

                    if(contactEmail != null && contactEmail.Contact != user.Email)
                    {
                        contactEmail.Contact = user.Email;
                        using (_db)
                        {
                            _db.Contact.Update(contactEmail);
                            _db.SaveChanges();
                        }
                    }

                    var phoneEmail = _db.Contact.Where(x => x.UserId == userEntity.Id 
                                                         && x.ContactType == ContactType.Phone.ToString()).FirstOrDefault();

                    if (phoneEmail != null && phoneEmail.Contact != user.Phone.ToBrazilFormatPhone())
                    {
                        phoneEmail.Contact = user.Phone.ToBrazilFormatPhone();
                        using (_db)
                        {
                            _db.Contact.Update(phoneEmail);
                            _db.SaveChanges();
                        }
                    }

                    return UserResponseOk("User Created with Success");
                }
                else
                {
                    var response = UserResponseError("The request is invalid.");
                    response.Notification = user.Notifications();
                    return response;
                }
            }
            catch (Exception ex)
            {
                return UserResponseError(ex.Message);
            }
        }

        private UserResponse UserResponseError(string message)
            => new UserResponse
            {
                Data = new Contract.Response.Data
                {
                    Status = Status.Error,
                    Message = message
                }
            };

        private UserResponse UserResponseOk(string message)
            => new UserResponse
            {
                Data = new Contract.Response.Data
                {
                    Status = Status.Sucessed,
                    Message = message
                }
            };
    }
}
