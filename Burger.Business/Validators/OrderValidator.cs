using BurgerStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Validators
{
    internal class OrderValidator
    {
        public ValidationResult Validate(Order order)
        {
            var validationResult = new ValidationResult();

            //if (order.CustomerId<=0)
            //{
            //    validationResult.AddError("Müşteri Bilgileri Boş Geçilemez");
            //}
            
            return validationResult;
        }
    }
}
