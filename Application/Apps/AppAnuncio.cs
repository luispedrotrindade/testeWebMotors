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
        IAnuncio _IAirPlane;

        public AppAnuncio(IAnuncio IAnuncio)
        {
            _IAirPlane = IAnuncio;
        }
        public void Add(Anuncio Entity)
        {
            _IAirPlane.Add(Entity);
        }

        public void Delete(Anuncio Entity)
        {
            _IAirPlane.Delete(Entity);
        }

        public Anuncio GetEntity(int id)
        {
            return _IAirPlane.GetEntity(id);
        }

        public List<Anuncio> List()
        {
            return _IAirPlane.List();
        }

        public void Update(Anuncio Entity)
        {
            _IAirPlane.Update(Entity);
        }
    }
}
