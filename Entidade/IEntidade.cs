using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public interface IEntidade
    {
       [Key]
            int id { get; set; }

               
    }
}
