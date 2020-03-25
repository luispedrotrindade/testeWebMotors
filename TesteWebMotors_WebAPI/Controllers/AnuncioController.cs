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
        private IAppAnuncio appAnuncio;


        public AnuncioController(IAppAnuncio _appAnuncio)
        {
            this.appAnuncio = _appAnuncio;
        }

        // GET: api/Anuncio
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var anuncios = appAnuncio.List();

                return StatusCode(200, anuncios);
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
                var anuncio = appAnuncio.GetEntity(id);
                return StatusCode(200, anuncio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Anuncio
        [HttpPost]
        public ActionResult Post([FromBody]Anuncio anuncio)
        {
            try
            {
                appAnuncio.Add(anuncio);
                return StatusCode(200, 1);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Anuncio/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Anuncio anuncio)
        {
            try
            {
                appAnuncio.Update(anuncio);
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
            try
            {
                var anuncio = appAnuncio.GetEntity(id);
                appAnuncio.Delete(anuncio);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
