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
                var model = new SqlParameter("@Model", Entity.Model);
                var qtdPassengers = new SqlParameter("@QtdPassengers", Entity.QtdPassengers);
                var creationDate = new SqlParameter("@CreationDate", Entity.CreationDate);
                db.Database.ExecuteSqlCommand("CreateAnuncio @Model, @QtdPassengers, @CreationDate", model, qtdPassengers, creationDate);
                db.SaveChanges();
            }
        }

        public void Update(Domain.Entities.Anuncio Entity)
        {
            using (var db = new ContextBase(_OptionsBuider.Options))
            {
                var id = new SqlParameter("@Id", Entity.Id);
                var model = new SqlParameter("@Model", Entity.Model);
                var qtdPassengers = new SqlParameter("@QtdPassengers", Entity.QtdPassengers);
                var creationDate = new SqlParameter("@CreationDate", Entity.CreationDate);
                db.Database.ExecuteSqlCommand("UpdateAnuncio @Id, @Model, @QtdPassengers, @CreationDate", id, model, qtdPassengers, creationDate);
                db.SaveChanges();
            }
        }

        public void Delete(Domain.Entities.Anuncio Entity)
        {
            using (var db = new ContextBase(_OptionsBuider.Options))
            {
                var param = new SqlParameter("@Id", Entity.Id);
                db.Database.ExecuteSqlCommand("DeleteAnuncio @Id", param);
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
                var param = new SqlParameter("@Id", Id);
                var airplanes = db.Anuncio.FromSqlRaw("GetById @Id", param).ToList();
                return airplanes[0];
            }
        }
    }
}
