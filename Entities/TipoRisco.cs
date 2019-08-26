using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public partial class TipoRisco
    {
        [Key]
        public int TipoRiscoId { get; set; }
        public string NomeTipoRisco { get; set; }
        public int Criticidade { get; set; }
        public string LocalTipoRisco { get; set; }

        public List<Risco> Risco { get; set; }

    }
}
