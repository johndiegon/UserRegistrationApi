using FluentValidation.Results;
using System.Collections.Generic;
using UserRegistrationApi.Application.Contract.Response;

namespace UserRegistrationApi.Application.Model
{
    public abstract class Validate
    {
        public Validate() { }

        internal ValidationResult ValidationResult { get; set; }

        public List<Notification> Notifications()
        {
            if (this.ValidationResult != null)
            {
                var notifications = new List<Notification>();

                foreach (var item in this.ValidationResult.Errors)
                {
                    var notification = new Notification
                    {
                        Exception = "Error.",
                        Message = item.ErrorMessage
                    };
                    notifications.Add(notification);
                }

                return notifications;
            }
            else
            {
                return null;
            }

        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }

    }
}
