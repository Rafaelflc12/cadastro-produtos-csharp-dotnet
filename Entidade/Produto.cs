using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class Produto : Base
    {
        
        public string nome { get; set; }
        public string descricao { get; set; }
        public int fornecedor_id { get; set; }

    }
}
