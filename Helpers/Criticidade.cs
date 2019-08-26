using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
    public class Criticidade
    {
        public int CriticidadeID { get; set; }
        public string TituloCriticidade { get; set; }

        public List<Criticidade> ListaCriticidade()
        {
           
            return new List<Criticidade> {
                new Criticidade { CriticidadeID = 1, TituloCriticidade = "Baixa"},
                new Criticidade { CriticidadeID = 2, TituloCriticidade = "Média"},
                new Criticidade { CriticidadeID = 3, TituloCriticidade = "Alta"}
            };
           
        }

        public string getTituloCriticidade(int id)
        {
            return new Criticidade().ListaCriticidade().Where(p => p.CriticidadeID == id).FirstOrDefault().TituloCriticidade;
        }
    }
}
