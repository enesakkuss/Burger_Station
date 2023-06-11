using BurgerStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Validators
{
    internal class CustomerValidator
    {
        public ValidationResult Validate(Customer customer)
        {
            var validationResult= new ValidationResult();

            if(string.IsNullOrWhiteSpace(customer.FirstName))
            {
                validationResult.AddError("İsim Boş Geçilemez");
            }
            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                validationResult.AddError("Soyad Boş Geçilemez");
            }
            if (string.IsNullOrWhiteSpace(customer.PhoneNumber))
            {
                validationResult.AddError("Telefon Numarası Boş Geçilemez");
            }
            if (string.IsNullOrWhiteSpace(customer.Mail))
            {
                validationResult.AddError("Mail Adresi Boş Geçilemez");
            }
            if (string.IsNullOrWhiteSpace(customer.Address))
            {
                validationResult.AddError("Adres Boş Geçilemez");
            }
            if(customer.DistrictId <= 0)
            {
                validationResult.AddError("Lütfen İlçe Seçiniz");
            }
            if(customer.NeighborhoodId <= 0)
            {
                validationResult.AddError("Lütfen Mahalle Seçiniz");
            }
            return validationResult;
        }
    }
}
