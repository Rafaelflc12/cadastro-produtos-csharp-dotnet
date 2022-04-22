using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class Item : Base
    {
        
        public float quantidade { get; set; }
        public float valor { get; set; }
        public int idPedido { get; set; }
        public int idProduto { get; set; }

    }
}
