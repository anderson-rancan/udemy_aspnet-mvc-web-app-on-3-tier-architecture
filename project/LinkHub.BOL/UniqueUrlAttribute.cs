using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkHub.BOL
{
    /// <summary>
    /// Implementação de atributo para verificação de cadastro de URL única
    /// </summary>
    public class UniqueUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LinkHubDbEntities db = new LinkHubDbEntities();

            string urlValue = value.ToString();
            int count = db.tbl_Url.Where(p => p.Url == urlValue).Count();

            if (count != 0)
                return new ValidationResult("Url Already Exist");
            else
                return ValidationResult.Success;
        }
    }
}
