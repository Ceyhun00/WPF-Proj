using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSON.Test.Data
{
    public class BookItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<AutorItem> AutorItems { get; set; }


    }
}
