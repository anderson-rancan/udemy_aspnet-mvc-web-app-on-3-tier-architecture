using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Criação da validação separada, pois as classes automáticas do Entity pode ser regeneradas e irão perder os atributos
 */

namespace LinkHub.BOL
{
    public class tbl_UserValidation
    {
        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    /*
     * Método para passagem de 'metadata' para outra classe, ótimo para acrescentar os atributos sem modificação da classe
    */

    [MetadataType(typeof(tbl_UserValidation))]
    public partial class tbl_User
    {

        public string ConfirmPassword { get; set; }

    }
}
