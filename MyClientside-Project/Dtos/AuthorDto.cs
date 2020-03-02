using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyClientside_Project.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }

        public Nullable<int> NationalityId { get; set; }

        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        public NationalityDto Nationality { get; set; }
    }
}