using BurgerStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Validators
{
    internal class FinalOrderValidator
    {
        public ValidationResult Validate(FinalOrder finalOrder)
        {
            var validationResult = new ValidationResult();

            if (finalOrder.CustomerId<=0)
            {
                validationResult.AddError("Müşteri Bilgileri Boş Geçilemez");
            }
           
            return validationResult;
        }
    }
}
