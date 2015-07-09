using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkHub.BOL
{
    /// <summary>
    /// Implementação de atributo para verificação de cadastro de e-mail único
    /// </summary>
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LinkHubDbEntities db = new LinkHubDbEntities();

            string userEmailValue = value as string;

            if (string.IsNullOrWhiteSpace(userEmailValue))
            {
                return new ValidationResult("User e-mail address cannot be empty");
            }
            else
            {
                int count = db.tbl_User.Where(p => p.UserEmail == userEmailValue).Count();

                if (count != 0)
                    return new ValidationResult("User already exist with this e-mail address");
                else
                    return ValidationResult.Success;
            }
        }
    }
}
