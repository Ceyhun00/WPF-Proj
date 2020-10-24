using System.Collections.Generic;

namespace JSON.Test.Data
{
    public class PhoneItem
    {
        public int id { get; set; }
        public string value { get; set; }
    }
    public class UserItem
    {
        public string name { get; set; }
        public string login { get; set; }
        public int group { get; set; }
        public List<PhoneItem> phones { get; set; }
    }
    
    
}
