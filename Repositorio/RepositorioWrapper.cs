using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratos;
using Microsoft.Extensions.Configuration;

namespace Repositorio
{
    public class RepositorioWrapper : IRepositorioWrapper
    {
        private  Entidade.configuracao.MeuBanco _myDB;


        private IConfiguration _configuration;
        public RepositorioWrapper(IConfiguration configuration, Entidade.configuracao.MeuBanco myDB)
        {
            _configuration = configuration;
            this._myDB = myDB;
        }

        private IFornecedorRepositorio _Fornecedor;
        public IFornecedorRepositorio Fornecedor
        {
            get
            {
                if (_Fornecedor == null)
                {
                    _Fornecedor = new FornecedorRepositorio(_myDB);
                }

                return _Fornecedor;
            }
        }


        private IEmailRepositorio _Email;
        public IEmailRepositorio Email
        {
            get
            {
                if (_Email == null)
                {
                    _Email = new EmailRepositorio(_myDB);
                }

                return _Email;
            }
        }

        private ITelefoneRepositorio _Telefone;
        public ITelefoneRepositorio Telefone
        {
            get
            {
                if (_Telefone == null)
                {
                    _Telefone = new TelefoneRepositorio(_myDB);
                }

                return _Telefone;
            }
        }


        private IProdutoRepositorio _Produto;
        public IProdutoRepositorio Produto
        {
            get
            {
                if (_Produto == null)
                {
                    _Produto = new ProdutoRepositorio(_myDB);
                }

                return _Produto;
            }
        }


        private IItemRepositorio _Item;
        public IItemRepositorio Item
        {
            get
            {
                if (_Item == null)
                {
                    _Item = new ItemRepositorio(_myDB);
                }

                return _Item;
            }
        }

        private IPedidoRepositorio _Pedido;
        public IPedidoRepositorio Pedido
        {
            get
            {
                if (_Pedido == null)
                {
                    _Pedido = new PedidoRepositorio(_myDB);
                }

                return _Pedido;
            }
        }


        private ITransportadoraRepositorio _Transportadora;
        public ITransportadoraRepositorio Transportadora
        {
            get
            {
                if (_Transportadora == null)
                {
                    _Transportadora = new TransportadoraRepositorio(_myDB);
                }

                return _Transportadora;
            }
        }
    }
}
