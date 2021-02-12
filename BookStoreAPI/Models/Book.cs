using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Models
{
    public class Book
    {

        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Title { get; set; }
        [MinLength(10),MaxLength(500)]
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public DateTime Published { get; set; }
       //if the book was read, or it's reading by someone
        public Boolean BookState { get; set; }
        public int AuthorId { get; set; }

        public List<Qualification> Qualification { get; set; }


    }
}
