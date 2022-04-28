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
        public int pedido_id{ get; set; }
        public int produto_id { get; set; }

    }
}
