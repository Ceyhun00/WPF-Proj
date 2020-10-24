using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSON.Test.Data
{
    public class Author
    {

        public int id { get; set; }
        public string name { get; set; }
        public List<Book> books { get; set; }
    }

}
