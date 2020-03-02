using AutoMapper;
using MyClientside_Project.Dtos;
using MyClientside_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyClientside_Project.Controllers.api
{
    public class NationalitiesController : ApiController
    {
        private MapperConfiguration mapperConfiguration;
        private IMapper mapper;
        private LibrarySystemEntities db = new LibrarySystemEntities();

        public NationalitiesController()
        {
            mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Nationality, NationalityDto>();
            });

            mapper = mapperConfiguration.CreateMapper();

            db = new LibrarySystemEntities();

            db.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        public IHttpActionResult GetNationality(int id)
        {
            var nationality = db.Nationalities.SingleOrDefault(n => n.Id == id);

            if (nationality == null) return NotFound();

            return Ok(mapper.Map<NationalityDto>(nationality));
        }

        [HttpGet]
        public IHttpActionResult GetNationalities()
        {
            var nationalityDtos = mapper
                .ProjectTo<NationalityDto>(db.Nationalities);

            return Ok(nationalityDtos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
