using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public partial class TipoRisco
    {
        [Key]
        public int TipoRiscoId { get; set; }
        public string NomeTipoRisco { get; set; }
        public string Criticidade { get; set; }
        public string LocalTipoRisco { get; set; }

        public List<Risco> Risco { get; set; }
        //public List<CriticidadeTipoRisco> ListaCriticidade
        //{
        //    get
        //    {
        //        return new List<CriticidadeTipoRisco> {
        //            new CriticidadeTipoRisco { codigoCriticidade = 1, tituloCriticidade = "Baixa"},
        //            new CriticidadeTipoRisco { codigoCriticidade = 2, tituloCriticidade = "Média"},
        //            new CriticidadeTipoRisco { codigoCriticidade = 3, tituloCriticidade = "Alta"},
        //            new CriticidadeTipoRisco { codigoCriticidade = 4, tituloCriticidade = "Urgente"}
        //        };
        //    }
        //}

        //public class CriticidadeTipoRisco{
        //    public int codigoCriticidade { get; set; }
        //    public string tituloCriticidade { get; set; }
        //}

    }
}
