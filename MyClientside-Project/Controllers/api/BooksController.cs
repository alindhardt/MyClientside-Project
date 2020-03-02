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
    public class BooksController : ApiController
    {
        private MapperConfiguration mapperConfiguration;
        private IMapper mapper;
        private LibrarySystemEntities db = new LibrarySystemEntities();

        public BooksController()
        {
            mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDto>();
                cfg.CreateMap<Author, AuthorDto>();
                cfg.CreateMap<Language, LanguageDto>();
            });

            mapper = mapperConfiguration.CreateMapper();

            db = new LibrarySystemEntities();

            db.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        public IHttpActionResult GetBook(int id)
        {
            var book = db.Books.SingleOrDefault(l => l.Id == id);

            if (book == null) return NotFound();

            return Ok(mapper.Map<BookDto>(book));
        }

        [HttpGet]
        public IHttpActionResult GetBooks()
        {
            var bookDtos = mapper
                .ProjectTo<BookDto>(db.Books);

            return Ok(bookDtos);
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
