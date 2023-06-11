using BurgerStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Validators
{
    internal class NeighborhoodValidator
    {
        public ValidationResult Validate(Neighborhood neighborhood)
        {
            var validationResult=new ValidationResult();

            if(string.IsNullOrWhiteSpace(neighborhood.Name))
            {
                validationResult.AddError("Mahalle Adı Boş Geçilemez");
            }
            if(neighborhood.DistrictId<=0)
            {
                validationResult.AddError("Lütfen Mahallenin Dahil Olduğu İlçeyi Seçiniz");
            }
            return validationResult;
        }
    }
}
