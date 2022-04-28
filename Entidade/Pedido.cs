using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class Pedido : Base
    {
        
        public DateTime dataHora { get; set; }
        public string notaFiscal { get; set; }
        public float valorFrete { get; set; }
        public float desconto { get; set; }
        public float valorTotal { get; set; }
        public int transportadora_id { get; set; }

        public List<Item> Item { get; set; }

    }
}
