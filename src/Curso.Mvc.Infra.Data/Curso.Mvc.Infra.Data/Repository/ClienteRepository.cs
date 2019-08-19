using System;
using System.Collections.Generic;
using System.Linq;
using Curso.Mvc.Domain.Intefaces;
using Curso.Mvc.Domain.Models;
using Curso.Mvc.Infra.Data.Context;
using Dapper;

namespace Curso.Mvc.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {

        public ClienteRepository(CursoMvcEssencialContext context) : base(context){ }

        public IEnumerable<Cliente> ObterAtivos()
        {
            var sql = @"SELECT * FROM Clientes c " +
                "WHERE c.Excluido = 0 AND c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente>(sql);
            //return Buscar(c => c.Ativo);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override Cliente ObterPorId(Guid id)
        {
            const string sql = @"SELECT * FROM Clientes c " +
                               "LEFT JOIN Enderecos e " +
                               "ON c.Id = e.ClienteId " +
                               "WHERE c.Id = @uid AND c.Excluido = 0 AND c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql,
                 (c, e) =>
                 {
                     c.AdicionarEndereco(e);
                     return c;
                 }, new { uid = id }).FirstOrDefault();

            // return Db.Clientes.AsNoTracking().Include("Enderecos").FirstOrDefault(c => c.Id == id);
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.DefinirComoExcluido();

            Atualizar(cliente);
        }

    }
}
