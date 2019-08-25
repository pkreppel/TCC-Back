using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public partial class Risco
    {
        [Key]
        public int RiscoId { get; set; }
        public int TipoRiscoId { get; set; }
        public string DescricaoRisco { get; set; }
        public DateTime DataCadastro { get; set; }
        public TipoRisco TipoRisco { get; set; }


    }
}
