using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace JSON.Test.Data
{
    public class AutorItem
    {
        public static ObservableCollection<AutorItem> Autors { get; set; } = new ObservableCollection<AutorItem>();
        public int id { get; set; }
        public string name { get; set; } = "new autor";
        public AutorItem BindingAutor
        {
            get { return Autors.Where(x=>x.name == name).FirstOrDefault();}
            set { name = value.name; }
        } 

        public List<BookItem> BookItems { get; set; }
    }
}
