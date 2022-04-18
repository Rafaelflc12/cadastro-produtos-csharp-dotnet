
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

using System.Threading.Tasks;
using Entidade.configuracao;
using Contratos;
using System.Data.Common;
using Dapper;

namespace Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {

        protected string conexao
        {
            get { return this.infConnection.conexao; }
        }
        protected infConnection infConnection { get; set; }

        private DbConnection GetConnection()
        {
            return new Npgsql.NpgsqlConnection(infConnection.conexao);

        }

        protected virtual string nomeTabela
        {
            get
            {
                return "";
            }
        }

        protected virtual string sqlInsert
        {
            get
            {
                return "";
            }

        }

        protected virtual string caracter
        {
            get
            {
                return "@";
            }
        }

        protected virtual string sqlUpdate
        {
            get
            {
                return "";
            }
        }



        private MeuBanco _myDB;
        public RepositorioBase(MeuBanco myDB)
        {

            _myDB = myDB;
            infConnection = _myDB.getStringConn();
        }



        protected void montarFiltro(ref string filtro, string sql)
        {
            var str = string.Empty;
            if (string.IsNullOrEmpty(filtro))
                filtro += " where ";
            else
                filtro += " and ";

            filtro += sql;
        }

        public async Task<List<T>> ListarTodos()
        {
            try
            {
                using (DbConnection conexao = GetConnection())
                {
                    return (List<T>)await conexao.QueryAsync<T>(string.Format("select  * from {0}", nomeTabela));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        

        public async Task Criar(T entity)
        {
            try
            {
                using (DbConnection conexao = GetConnection())
                {

                    await conexao.ExecuteAsync(sqlInsert, entity);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public  async Task Alterar(T entity)
        {
            try
            {


                using (DbConnection conexao = GetConnection())
                {
                    await conexao.ExecuteAsync(sqlUpdate, entity);
                }
            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public async Task Excluir(T entity)
        {
            try
            {
                Entidade.IEntidade entidade = (Entidade.IEntidade)entity;
                using (DbConnection conexao = GetConnection())
                {
                    await conexao.ExecuteAsync(string.Format("delete from {0} where id={1}id", nomeTabela, caracter), 
                        new { id = entidade.id });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

      
       

        public async Task<T> ObterPorId(int Id)
        {
            try
            {
                using (DbConnection conexao = GetConnection())
                {
                    return await conexao.QueryFirstOrDefaultAsync<T>(string.Format("select  * from {0} where id = @id", nomeTabela), new {id=Id});
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}