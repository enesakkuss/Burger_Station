using BurgerStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Validators
{
    internal class DistrictValidator
    {
        public ValidationResult Validate (District district)
        {
            var validationResult= new ValidationResult ();
            {
                if (string.IsNullOrWhiteSpace(district.Name))
                {
                    validationResult.AddError("İlçe Adı Boş Geçilemez");
                }
            }
            return validationResult;
        }
    }
}
