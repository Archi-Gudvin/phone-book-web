using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfApp.Models;

namespace WpfApp
{
    public static class Ext
    {
        public static double ToDouble(this string e) => Convert.ToDouble(e);

        public static ObservableCollection<Client> ToObservableCollection(this IEnumerable<Client> e)
        {
            ObservableCollection<Client> t = new ObservableCollection<Client>();
            foreach (var item in e)
            {
                t.Add(item);
            }
            return t;
        }


    }
}
