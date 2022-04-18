using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Entidade.configuracao
{
    public class infConnection
    {
        public string conexao { get; set; }
        public string db { get; set; }
    }
    public class MeuBanco
    {
        private static IConfiguration _config;
        public MeuBanco(IConfiguration config)
        {
            _config = config;
        }

        private infConnection _infConnection { get; set; }

        public infConnection getStringConn()
        {
            if (_infConnection == null)
            {

                _infConnection = new infConnection();



                _infConnection.conexao = _config["conexao:connectionString"];
                _infConnection.db = _config["conexao:db"];


            }

            return _infConnection;
        }
    }
}
