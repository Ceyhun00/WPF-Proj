using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace JSON.Test.Data
{
   public class Book
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public List<Author> authors { get; set; }
    }
}
