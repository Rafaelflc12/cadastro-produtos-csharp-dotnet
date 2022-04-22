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
        public  Entidade.configuracao.MeuBanco _myDB;


        public IConfiguration _configuration;
        public RepositorioWrapper(IConfiguration configuration, Entidade.configuracao.MeuBanco myDB)
        {
            _configuration = configuration;
            this._myDB = myDB;
        }

        public IFornecedorRepositorio _Fornecedor;
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


        public IEmailRepositorio _Email;
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

        public ITelefoneRepositorio _Telefone;
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


        public IProdutoRepositorio _Produto;
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


        public IItemRepositorio _Item;
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

        public IPedidoRepositorio _Pedido;
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


        public ITransportadoraRepositorio _Transportadora;
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
