using MyClientside_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using MyClientside_Project.Dtos;

namespace MyClientside_Project.Controllers.api
{
    public class AuthorsController : ApiController
    {
        private MapperConfiguration mapperConfiguration;
        private IMapper mapper;
        private LibrarySystemEntities db;

        public AuthorsController()
        {
            mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorDto>();
                cfg.CreateMap<Nationality, NationalityDto>();
            });

            mapper = mapperConfiguration.CreateMapper();

            db = new LibrarySystemEntities();

            db.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        public IHttpActionResult GetAuthor(int id)
        {
            var author = db.Authors.SingleOrDefault(a => a.Id == id);

            if (author == null) return NotFound();

            return Ok(mapper.Map<AuthorDto>(author));
        }

        [HttpGet]
        public IHttpActionResult GetAuthors()
        {
            var authorDtos = mapper
                .ProjectTo<AuthorDto>(db.Authors.Include(a => a.Nationality));

            return Ok(authorDtos);
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
