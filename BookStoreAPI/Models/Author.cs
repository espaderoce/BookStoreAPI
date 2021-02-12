using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required,MinLength(3),MaxLength(100)]
        public string Name { get; set; }
        [MinLength(3), MaxLength(100)]
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }

        public List<Book> Book { get; set; }


    }
}
