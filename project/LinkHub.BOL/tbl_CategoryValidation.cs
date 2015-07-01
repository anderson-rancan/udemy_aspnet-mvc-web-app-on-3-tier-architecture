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
    public class tbl_CategoryValidation
    {
        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string CategoryDesc { get; set; }
    }

    /*
     * Método para passagem de 'metadata' para outra classe, ótimo para acrescentar os atributos sem modificação da classe
     */

    [MetadataType(typeof(tbl_CategoryValidation))]
    public partial class tbl_Category
    {
    }
}
