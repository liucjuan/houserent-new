using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

/// <summary>
/// SetValueOfClass 的摘要说明
/// </summary>
public class SetValueOfClass
{
	public SetValueOfClass()
	{
	}

    public static PropertyInfo[] GetPropertyInfoArray<T>(T tClass)
    {
        PropertyInfo[] props = null;
        try
        {
            Type type = typeof(T);
            object obj = Activator.CreateInstance(type);
            props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
        catch (Exception ex)
        { }
        return props;
    }

    /// <summary>
    /// 设置相应属性的值
    /// </summary>
    /// <param name="entity">实体</param>
    /// <param name="fieldName">属性名</param>
    /// <param name="fieldValue">属性值</param>
    public static void SetValue(object entity, string fieldName, string fieldValue)
    {
        Type entityType = entity.GetType();

        PropertyInfo propertyInfo = entityType.GetProperty(fieldName);

        if (IsType(propertyInfo.PropertyType, "System.String"))
        {
            if (string.IsNullOrEmpty(fieldValue))
            {
                fieldValue = string.Empty;
            }
            propertyInfo.SetValue(entity, fieldValue, null);

        }

        if (IsType(propertyInfo.PropertyType, "System.Boolean"))
        {
            if (string.IsNullOrEmpty(fieldValue))
            {
                fieldValue = "false";
            }
            propertyInfo.SetValue(entity, Boolean.Parse(fieldValue), null);

        }

        if (IsType(propertyInfo.PropertyType, "System.Int32"))
        {
            if (fieldValue != "")
                propertyInfo.SetValue(entity, int.Parse(fieldValue), null);
            else
                propertyInfo.SetValue(entity, 0, null);

        }

        if (IsType(propertyInfo.PropertyType, "System.Decimal"))
        {
            if (fieldValue != "")
                propertyInfo.SetValue(entity, Decimal.Parse(fieldValue), null);
            else
                propertyInfo.SetValue(entity, new Decimal(0), null);

        }

        if (IsType(propertyInfo.PropertyType, "System.Nullable`1[System.DateTime]"))
        {
            if (fieldValue != "")
            {
                try
                {
                    propertyInfo.SetValue(
                        entity,
                        (DateTime?)DateTime.ParseExact(fieldValue, "yyyy-MM-dd HH:mm:ss", null), null);
                }
                catch
                {
                    propertyInfo.SetValue(entity, (DateTime?)DateTime.ParseExact(fieldValue, "yyyy-MM-dd", null), null);
                }
            }
            else
                propertyInfo.SetValue(entity, null, null);

        }

    }

    /// <summary>
    /// 类型匹配
    /// </summary>
    /// <param name="type"></param>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public static bool IsType(Type type, string typeName)
    {
        if (type.ToString() == typeName)
            return true;
        if (type.ToString() == "System.Object")
            return false;

        return IsType(type.BaseType, typeName);
    }
}