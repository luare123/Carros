using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros
{
    [Serializable]
    public class Carro
    {
        public int ID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Fabricante { get; set; }
        public string Tipo { get; set; }
        public int Ano { get; set; }
        public string Combustível { get; set; }
        public string Cor { get; set; }
        public int NumChassi { get; set; }
        public int Kilometragem { get; set; }
        public string Revisão { get; set; }
        public string Sinistro { get; set; }
        public string Roubo_Furto { get; set; }
        public string Aluguel { get; set; }
        public string Venda { get; set; }
        public string Particular { get; set; }
        public string Observações { get; set; }
    }
}
