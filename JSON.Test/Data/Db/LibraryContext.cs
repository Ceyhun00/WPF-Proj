using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace JSON.Test.Data
{
   public class LibraryContext : DbContext
    {
        public LibraryContext() : base("DefaultConnection")
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Base> baseParameters { get; set; }
       
    }
}
