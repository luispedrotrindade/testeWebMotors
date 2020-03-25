using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Anuncio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Apps
{
    public class AppAnuncio : IAppAnuncio
    {
        IAnuncio _IAnuncio;

        public AppAnuncio(IAnuncio IAnuncio)
        {
            _IAnuncio = IAnuncio;
        }
        public void Add(Anuncio Entity)
        {
            _IAnuncio.Add(Entity);
        }

        public void Delete(Anuncio Entity)
        {
            _IAnuncio.Delete(Entity);
        }

        public Anuncio GetEntity(int id)
        {
            return _IAnuncio.GetEntity(id);
        }

        public List<Anuncio> List()
        {
            return _IAnuncio.List();
        }

        public void Update(Anuncio Entity)
        {
            _IAnuncio.Update(Entity);
        }
    }
}
