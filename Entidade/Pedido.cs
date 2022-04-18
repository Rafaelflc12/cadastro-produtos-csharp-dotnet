using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class Pedido
    {
        public int id { get; set; }
        public DateTime dataHora { get; set; }
        public string notaFiscal { get; set; }
        public float valorFrete { get; set; }
        public float desconto { get; set; }
        public float valorTotal { get; set; }
        public int idTransportadora { get; set; }

    }
}
