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
    public class tbl_UrlValidation
    {
        [Required]
        public string UrlTitle { get; set; }

        [Required]
        [Url]
        [UniqueUrl]
        public string Url { get; set; }

        [Required]
        public string UrlDesc { get; set; }
    }

    /*
     * Método para passagem de 'metadata' para outra classe, ótimo para acrescentar os atributos sem modificação da classe
     */

    [MetadataType(typeof(tbl_UrlValidation))]
    public partial class tbl_Url
    {
    }
}
