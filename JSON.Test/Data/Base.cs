using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Windows;

namespace JSON.Test.Data
{
    public class DataTypeAttribute : System.Attribute
    {
        public string Name { get; set; }

        public DataTypeAttribute()
        { }

        public DataTypeAttribute(string name)
        {
            Name = name;
        }
    }
    public class Item : DataTypeAttribute
    {
        [DataType("HOUSES")]
        public Base<HouseItem> GetHouses(string json)
        {
            try
            {
                Base<HouseItem> res = JsonConvert.DeserializeObject<Base<HouseItem>>(json);
                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        [DataType("USERS")]
        public Base<UserItem> GetUsers(string json)
        {
            try
            {
                Base<UserItem> res = JsonConvert.DeserializeObject<Base<UserItem>>(json);
                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        [DataType("AUTORS")]
        public Base<AutorItem> GetAutors(string json)
        {
            try
            {
                Base<AutorItem> res = JsonConvert.DeserializeObject<Base<AutorItem>>(json);
                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        [DataType("BOOKS")]
        public Base<BookItem> GetBooks(string json)
        {
            try
            {
                Base<BookItem> res = JsonConvert.DeserializeObject<Base<BookItem>>(json);
                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        /// <summary>
        /// Возвращает распарсенные данные
        /// </summary>
        public object GetData(string json)
        {
            try
            {
                Base obj = JsonConvert.DeserializeObject<Base>(json);
                if (obj != null)
                {
                    foreach (MethodInfo methodinfo in typeof(Item).GetMethods())
                    {
                        DataTypeAttribute attribute = (DataTypeAttribute)Attribute.GetCustomAttribute(methodinfo, typeof(DataTypeAttribute));
                        if (attribute != null && attribute.Name == obj.Q)
                        {
                            try
                            {
                                object res = methodinfo.Invoke(this, new object[] { json });
                                return res;
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
    }
    public class Base
    {
        [Key]
        public float T { get; set; }
        public string Q { get; set; }
        public int R { get; set; }

    }
    public class Base<O>
    {
        public string Q { get; set; }
        public int R { get; set; }
        public ulong T { get; set; }
        public D<O> D { get; set; }
    }
    public class D<T>
    {
        public int count { get; set; }
        public List<T> items { get; set; }
    }
}
