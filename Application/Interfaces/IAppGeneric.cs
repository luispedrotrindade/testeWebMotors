using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IAppGeneric<T> where T : class
    {
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        T GetEntity(int id);
        List<T> List();
    }
}
