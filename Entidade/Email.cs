using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class Email : Base
    {
        
        public string email { get; set; }
        public string referencia { get; set; }
        
        public int fornecedor_id { get; set; }
    }
}
