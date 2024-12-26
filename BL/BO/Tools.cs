using System;
using System.Reflection;
/// <summary>
/// tools definition
/// </summary>

namespace BO
{
    internal static class Tools
    {
        public static string ToStringProperty(this object obj)
        {

            Type type = obj.GetType();//סוג OBJ
            PropertyInfo[] properties = type.GetProperties();//יודע את כל התכונות של OBJ


            string str = "";//הוספה
            foreach (var property in properties)//הוספה
            {
                str += property.Name + ":" + property.GetValue(obj);//הוספה

            }
            return str;//הוספה
        }
    }
}
  