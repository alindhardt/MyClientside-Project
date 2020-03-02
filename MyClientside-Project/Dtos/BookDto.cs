using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyClientside_Project.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public Nullable<int> AuthorId { get; set; }
        public Nullable<int> LanguageId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public Nullable<int> NumberOfPages { get; set; }
        public Nullable<int> NumberOfChapters { get; set; }

        public AuthorDto Author { get; set; }
        public LanguageDto Language { get; set; }
    }
}