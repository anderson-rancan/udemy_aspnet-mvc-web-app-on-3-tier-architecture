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

            string userEmailValue = value.ToString();
            int count = db.tbl_User.Where(p => p.UserEmail == userEmailValue).Count();

            if (count != 0)
                return new ValidationResult("User already exist with this email address");
            else
                return ValidationResult.Success;
        }
    }
}
