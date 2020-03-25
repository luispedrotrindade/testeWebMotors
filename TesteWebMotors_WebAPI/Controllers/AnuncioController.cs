using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TesteWebMotors_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private IAppAnuncio appAirPlane;


        public AnuncioController(IAppAnuncio _appAnuncio)
        {
            this.appAirPlane = _appAnuncio;
        }

        // GET: api/Anuncio
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var airplanes = appAirPlane.List();

                return StatusCode(200, airplanes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Anuncio/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            try
            {
                var airPlane = appAirPlane.GetEntity(id);
                return StatusCode(200, airPlane);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Anuncio
        [HttpPost]
        public ActionResult Post([FromBody]Anuncio airplane)
        {
            try
            {
                airplane.CreationDate = DateTime.Now;
                appAirPlane.Add(airplane);
                return StatusCode(200, 1);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Anuncio/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Anuncio airplane)
        {
            try
            {
                appAirPlane.Update(airplane);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var airplane = appAirPlane.GetEntity(id);
            appAirPlane.Delete(airplane);
            return StatusCode(200);
        }
    }
}
