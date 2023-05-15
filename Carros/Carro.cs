using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CarrosCS
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
        public string Combustivel { get; set; }
        public string Cor { get; set; }
        public string NºChassi { get; set; }
        public int Kilometragem { get; set; }
        public bool Revisao { get; set; }
        public bool Sinistro { get; set; }
        public bool RouboFurto { get; set; }
        public bool Aluguel { get; set; }
        public bool Venda { get; set; }
        public bool Particular { get; set; }
        public string Observacoes { get; set; }
    }
}

