﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class Telefone : Base
    {
        
        public string  ddd { get; set; }
        public string numero { get; set; }
        public string referencia { get; set; }
        public int fornecedor_id { get; set; }

    }
}
