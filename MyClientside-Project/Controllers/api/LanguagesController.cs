using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using MyClientside_Project.Dtos;
using MyClientside_Project.Models;

namespace MyClientside_Project.Controllers.api
{
    public class LanguagesController : ApiController
    {
        private MapperConfiguration mapperConfiguration;
        private IMapper mapper;
        private LibrarySystemEntities db = new LibrarySystemEntities();

        public LanguagesController()
        {
            mapperConfiguration = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Language, LanguageDto>();
            });

            mapper = mapperConfiguration.CreateMapper();

            db = new LibrarySystemEntities();

            db.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        public IHttpActionResult GetLanguage(int id)
        {
            var language = db.Languages.SingleOrDefault(l => l.Id == id);

            if (language == null) return NotFound();

            return Ok(mapper.Map<LanguageDto>(language));
        }

        [HttpGet]
        public IHttpActionResult GetLanguages()
        {
            var languageDtos = mapper
                .ProjectTo<LanguageDto>(db.Languages);

            return Ok(languageDtos);
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