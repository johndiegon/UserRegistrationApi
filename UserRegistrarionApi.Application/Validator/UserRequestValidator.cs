using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationApi.Application.Contract.Request;
using UserRegistrationApi.Application.Enuns;
using UserRegistrationApi.Application.Helper;

namespace UserRegistrationApi.Application.Validator
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("{PropertyName} cannot be null");

            RuleFor(x => x.Cep)
                .NotNull()
                .WithMessage("{PropertyName} cannot be null");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("A valid email address is required.");

            RuleFor(x => x.DocumentType)
              .IsInEnum()
              .WithMessage("A valid document type is required.");

            RuleFor(x => x)
             .Must(x => BeADocumentValid(x.DocumentType, x.Document))
             .WithMessage("A valid document type is required.");

            RuleFor(x => x.Phone)
              .Must( x => x.IsPhone())
              .WithMessage("A valid document type is required.");

            RuleFor(x => x.Gender)
              .IsInEnum()
              .WithMessage("A valid gender type is required.");

            RuleFor(x => x.DateBirth)
              .NotEmpty()
              .WithMessage("{PropertyName} cannot be null")
              .LessThan(x => DateTime.Now)
              .WithMessage("The date needs to be in the past.");
        }

        private bool BeADocumentValid(DocumentType documentType , string docNumber)
       {
           if (docNumber != null)
           {
               docNumber = docNumber.Trim();
               docNumber = docNumber.Replace(".", "").Replace("-", "").Replace("/", "");

               switch (docNumber.Length)
               {
                   case 11:
                       if (documentType == DocumentType.CPF)
                           return docNumber.IsCPF();
                       else return false;
                   case 14:
                       if (documentType == DocumentType.CNPJ)
                           return docNumber.IsCnpj();
                       else return false;
                   default:
                       return false;
               }
           }
           return false;
       }
    }
}
