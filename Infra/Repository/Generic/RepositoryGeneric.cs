using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Interfaces.Generic;
using Infra.Config;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Generic
{
    public class RepositoryGeneric<T> : ICrudGeneric<T> where T : class
    {
        private readonly DbContextOptionsBuilder<ContextBase> _OptionsBuilder;

        public RepositoryGeneric()
        {
            _OptionsBuilder = new DbContextOptionsBuilder<ContextBase>();
        }


        public void Add(T Entity)
        {
            using (var db = new ContextBase(_OptionsBuilder.Options))
            {
                db.Set<T>().Add(Entity);
                db.SaveChanges();
            }
        }

        public void Delete(T Entity)
        {
            using (var db = new ContextBase(_OptionsBuilder.Options))
            {
                db.Set<T>().Remove(Entity);
                db.SaveChanges();
            }
        }


        public T GetEntity(int id)
        {
            using (var db = new ContextBase(_OptionsBuilder.Options))
            {
                return db.Set<T>().Find(id);
            }
        }

        public List<T> List()
        {
            using (var db = new ContextBase(_OptionsBuilder.Options))
            {
                return db.Set<T>().AsNoTracking().ToList();
            }
        }

        public void Update(T Entity)
        {
            using (var db = new ContextBase(_OptionsBuilder.Options))
            {
                db.Set<T>().Update(Entity);
                db.SaveChanges();
            }
        }
    }
}
