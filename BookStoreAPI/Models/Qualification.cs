using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Models
{
    public class Qualification
    {
        public int Id { get; set; }
        public string NameUser { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public int BookId { get; set; }

       
    }
}
