using Domain.Interfaces.Anuncio;
using Infra.Config;
using Infra.Repository.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repository.Anuncio
{
    public class RepositoryAnuncio : RepositoryGeneric<Domain.Entities.Anuncio>, IAnuncio
    {
        private readonly DbContextOptionsBuilder<ContextBase> _OptionsBuider;
        public RepositoryAnuncio()
        {
            _OptionsBuider = new DbContextOptionsBuilder<ContextBase>();
        }


        public void Add(Domain.Entities.Anuncio Entity)
        {
            using (var db = new ContextBase(_OptionsBuider.Options))
            {
                var marca = new SqlParameter("@marca", Entity.marca);
                var modelo = new SqlParameter("@modelo", Entity.modelo);
                var versao = new SqlParameter("@versao", Entity.versao);
                var ano = new SqlParameter("@ano", Entity.ano);
                var quilometragem = new SqlParameter("@quilometragem", Entity.quilometragem);
                var observacao = new SqlParameter("@observacao", Entity.observacao);
                db.Database.ExecuteSqlCommand("CreateAnuncio @marca, @modelo, @versao, @ano, @quilometragem, @observacao", marca, modelo, versao, ano, quilometragem, observacao);
                db.SaveChanges();
            }
        }

        public void Update(Domain.Entities.Anuncio Entity)
        {
            using (var db = new ContextBase(_OptionsBuider.Options))
            {
                var id = new SqlParameter("@id", Entity.id);
                var marca = new SqlParameter("@marca", Entity.marca);
                var modelo = new SqlParameter("@modelo", Entity.modelo);
                var versao = new SqlParameter("@versao", Entity.versao);
                var ano = new SqlParameter("@ano", Entity.ano);
                var quilometragem = new SqlParameter("@quilometragem", Entity.quilometragem);
                var observacao = new SqlParameter("@observacao", Entity.observacao);
                db.Database.ExecuteSqlCommand("UpdateAnuncio @id, @marca, @modelo, @versao, @ano, @quilometragem, @observacao", id, marca, modelo, versao, ano, quilometragem, observacao);
                db.SaveChanges();
            }
        }

        public void Delete(Domain.Entities.Anuncio Entity)
        {
            using (var db = new ContextBase(_OptionsBuider.Options))
            {
                var param = new SqlParameter("@id", Entity.id);
                db.Database.ExecuteSqlCommand("DeleteAnuncio @id", param);
                db.SaveChanges();
            }
        }

        public List<Domain.Entities.Anuncio> List()
        {
            using (var db = new ContextBase(_OptionsBuider.Options))
            {
                return db.Anuncio.FromSqlRaw("ListAll").ToList();
            }
        }

        public Domain.Entities.Anuncio GetEntity(int Id)
        {
            using (var db = new ContextBase(_OptionsBuider.Options))
            {
                var id = new SqlParameter("@id", Id);
                var anuncios = db.Anuncio.FromSqlRaw("GetById @id", id).ToList();
                return anuncios[0];
            }
        }
    }
}
