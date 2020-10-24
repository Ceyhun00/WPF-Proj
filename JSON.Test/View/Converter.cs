using System;
using System.Collections.Generic;
using System.Windows.Data;
using JSON.Test.Data;

namespace JSON.Test.View
{
    public class HouseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<HouseItem> items = (List<HouseItem>)values[1];
            return items.IndexOf((HouseItem)values[0]);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class UserConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<UserItem> items = (List<UserItem>)values[1];
            return items.IndexOf((UserItem)values[0]);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class PhoneConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<PhoneItem> items = (List<PhoneItem>)values[1];
            return items.IndexOf((PhoneItem)values[0]);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class AutorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<AutorItem> items = (List<AutorItem>)values[1];
            return items.IndexOf((AutorItem)values[0]);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class BookConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<BookItem> items = (List<BookItem>)values[1];
            return items.IndexOf((BookItem)values[0]);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
