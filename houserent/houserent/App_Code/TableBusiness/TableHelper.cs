using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace houserent.App_Code.TableBusiness
{
    public class TableHelper
    {
        public bool AddData<T,String>(T t, string tableName)
        {
            PropertyInfo[] props = null;
            try
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                if (props != null && props.Count() > 0)
                {
                    foreach (var item in props)
                    {
                        item.GetValue(t);
                    }
                }
            }
            catch (Exception ex)
            { 
             
            }
            return false;
        }
    }
}