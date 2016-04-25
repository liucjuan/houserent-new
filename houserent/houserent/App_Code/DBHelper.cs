using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// DBHelper 的摘要说明
/// </summary>
public class DBHelper
{
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    public static string connectStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBLink"].ToString();

    #region 获取数据库连接
    private static SqlConnection connection;
    public static SqlConnection Connection
    {
        get
        {
            string connectionString = connectStr;
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            else if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            else if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Open();
            }
            return connection;
        }
    } 
    #endregion

    #region 执行无参SQL语句
    /// <summary> 
    /// 执行无参SQL语句 
    /// </summary> 
    public static int ExecuteCommand(string safeSql)
    {
        try
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    
    #endregion

    #region 执行无参SQL语句，并返回执行记录数 
    /// <summary> 
    /// 执行无参SQL语句，并返回执行记录数 
    /// </summary> 
    public static int GetScalar(string safeSql)
    {
        try
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        catch (Exception ex)
        {
            return 0;
        }
    } 
    #endregion

    #region 执行无参SQL语句，并返所查询的字段
    /// <summary> 
    /// 执行无参SQL语句，并返所查询的字段 
    /// </summary> 
    public static object GetScalarTwo(string safeSql)
    {
        try
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            object result =cmd.ExecuteScalar();
            return result;
        }
        catch (Exception ex)
        {
            return new object();
        }
    }
    #endregion

    #region  执行无参SQL语句，并返回SqlDataReader 
    /// <summary> 
    /// 执行无参SQL语句，并返回SqlDataReader 
    /// </summary> 
    public static SqlDataReader GetReader(string safeSql)
    {
        try
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    
    #endregion

    #region 获取数据集
    public static DataSet GetDataSet(string sql)
    {
        try
        {
            DataSet ds = new DataSet();
            SqlDataAdapter sqld = new SqlDataAdapter(sql, Connection);
            sqld.Fill(ds, "user");
            DataTable dTable = ds.Tables["user"];
            DataRowCollection rows = dTable.Rows;
            if (rows.Count > 0)
            {
                return ds;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
        return null;
    }
    #endregion

    #region 数据查询
    public static DataSet SelectDataSet(List<string> fieldList, Dictionary<string, string> whereDic, string tableName)
    {
        DataSet ds = new DataSet();
        string fields = string.Empty;
        string wheres = string.Empty;
        if (fieldList != null && fieldList.Count > 0)
        {
            fields = GetListValue(fieldList);
            if (string.IsNullOrEmpty(fields))
            {
                fields = "*";
            }
        }
        else
        {
            fields = "*";
        }

        if (whereDic != null && whereDic.Count > 0)
        {
            List<string> wheresList = GetDictionaryKeyAndValue(whereDic);
            if (wheresList != null && wheresList.Count > 0)
            {
                foreach (string item in wheresList)
                {
                    wheres += "and " + item;
                }
            }
        }

        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("select {0} from {1} where 1=1 {2}",fields,tableName,wheres);
        ds = GetDataSet(sql.ToString());
        return ds;
    }

    public static SqlDataReader SelectReader(List<string> fieldList, Dictionary<string, string> whereDic, string tableName)
    {
        string fields = string.Empty;
        string wheres = string.Empty;
        if (fieldList != null && fieldList.Count > 0)
        {
            fields = GetListValue(fieldList);
            if (string.IsNullOrEmpty(fields))
            {
                fields = "*";
            }
        }
        else
        {
            fields = "*";
        }

        if (whereDic != null && whereDic.Count > 0)
        {
            List<string> wheresList = GetDictionaryKeyAndValue(whereDic);
            if (wheresList != null && wheresList.Count > 0)
            {
                foreach (string item in wheresList)
                {
                    wheres += " and " + item;
                }
            }
        }

        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("select {0} from {1} where 1=1 {2}", fields, tableName, wheres);
        SqlDataReader reader = GetReader(sql.ToString());
        return reader;
    }

    public static int SelectDataCount(List<string> fieldList, Dictionary<string, string> whereDic, string tableName)
    {
        string fields = string.Empty;
        string wheres = string.Empty;
        if (fieldList != null && fieldList.Count > 0)
        {
            fields = GetListValue(fieldList);
            if (string.IsNullOrEmpty(fields))
            {
                fields = "*";
            }
        }
        else
        {
            fields = "*";
        }

        if (whereDic != null && whereDic.Count > 0)
        {
            List<string> wheresList = GetDictionaryKeyAndValue(whereDic);
            if (wheresList != null && wheresList.Count > 0)
            {
                foreach (string item in wheresList)
                {
                    wheres += "and " + item;
                }
            }
        }
        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("select {0} from {1} where 1=1 {2}", fields, tableName, wheres);
        int count = GetScalar(sql.ToString());
        return count;
    }


    public static object SelectDataObject(List<string> fieldList, Dictionary<string, string> whereDic, string tableName)
    {
        string fields = string.Empty;
        string wheres = string.Empty;
        if (fieldList != null && fieldList.Count > 0)
        {
            fields = GetListValue(fieldList);
            if (string.IsNullOrEmpty(fields))
            {
                fields = "*";
            }
        }
        else
        {
            fields = "*";
        }

        if (whereDic != null && whereDic.Count > 0)
        {
            List<string> wheresList = GetDictionaryKeyAndValue(whereDic);
            if (wheresList != null && wheresList.Count > 0)
            {
                foreach (string item in wheresList)
                {
                    wheres += "and " + item;
                }
            }
        }
        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("select {0} from {1} where 1=1 {2}", fields, tableName, wheres);
        object two = GetScalarTwo(sql.ToString());
        return two;
    } 

    #endregion

    #region 数据更新
    public static ErrorType UpdateData(Dictionary<string, string> updateDic, Dictionary<string, string> whereDic, string tableName)
    {
        string fieldsEquValue = string.Empty;
        string where = string.Empty;
        if (updateDic != null && updateDic.Count > 0)
        {
            List<string> fieldsEquValueList = GetDictionaryKeyAndValue(updateDic);
            if (fieldsEquValueList != null && fieldsEquValueList.Count>0)
            {
                int i = 1;
                int j = fieldsEquValueList.Count;
                foreach (string item in fieldsEquValueList)
                {
                    if (i != j)
                    {
                        fieldsEquValue += item + ",";  
                    }
                    else
                    {
                        fieldsEquValue += item;  
                    }
                    i++;
                }
            }
        }
        if (whereDic != null && whereDic.Count > 0)
        {
            List<string> whereList = new List<string>();
            whereList = GetDictionaryKeyAndValue(whereDic);
            if (whereList != null && whereList.Count > 0)
            { 
                foreach(string temp in whereList)
                {
                    where += "and " + temp;
                }
            }
        }
        if (string.IsNullOrEmpty(fieldsEquValue) && string.IsNullOrEmpty(where))
        {
            return ErrorType.BadUpdate;
        }
        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("update {0} set {1} where 1=1 {2}", tableName,fieldsEquValue, where);
        int count = ExecuteCommand(sql.ToString());
        if (count == 1)
        {
            return ErrorType.Success;
        }
        else
        {
            return ErrorType.Failed;
        }
    } 
    #endregion

    #region 数据删除
    public static ErrorType DeleteData(Dictionary<string, string> whereDic, string tableName)
    {
        string where = string.Empty;
        if (whereDic != null && whereDic.Count > 0)
        {
            List<string> whereList = new List<string>();
            whereList = GetDictionaryKeyAndValue(whereDic);
            if (whereList != null && whereList.Count > 0)
            {
                foreach (string temp in whereList)
                {
                    where += "and " + temp;
                }
            }
        }
        if (string.IsNullOrEmpty(where))
        {
            return ErrorType.BadWhere;
        }
        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("delete from {0} where 1=1 {1}", tableName, where);
        int count = ExecuteCommand(sql.ToString());
        if (count == 1)
        {
            return ErrorType.Success;
        }
        else
        {
            return ErrorType.Failed;
        }
    }
    #endregion

    #region 数据增加
    public static ErrorType AddData(Dictionary<string, string> fieldsAndValue, string tableName)
    {
        if (fieldsAndValue != null && fieldsAndValue.Count > 0)
        {
            StringBuilder sql = new StringBuilder();
            string fields = GetDictionFieldsOrvalue(fieldsAndValue, 1);
            string value = GetDictionFieldsOrvalue(fieldsAndValue, 2); ;
            if (!string.IsNullOrEmpty(fields) && !string.IsNullOrEmpty(value))
            {
                sql.AppendFormat("insert into {0} ({1}) values ({2})", tableName, fields, value);
                int reuslt = ExecuteCommand(sql.ToString());
                if (reuslt == 1)
                {
                    return ErrorType.Success;
                }
            }
        }
        return ErrorType.Failed;
    }
    #endregion

    #region 单表分页
    public static DataSet Pagination( int pageSize, int pageIndex, Dictionary<string, string> whereDic, string id, string tableName)
    {
        string wheres = string.Empty;
        StringBuilder sql = new StringBuilder();
        if (whereDic != null && whereDic.Count > 0)
        {
            List<string> wheresList = GetDictionaryKeyAndValue(whereDic);
            if (wheresList != null && wheresList.Count > 0)
            {
                foreach (string item in wheresList)
                {
                    wheres += " and " + item;
                }
            }
        }
        int sum = pageIndex > 0 ? (pageIndex)*pageSize : 0;
        sql.AppendFormat("select top {0} * from {1} where 1=1 {2} and {3} not in (select top {4} {3} from {1} order by {3} desc) order by {3} desc", pageSize, tableName, wheres, id, sum);
        DataSet ds = DBHelper.GetDataSet(sql.ToString());
        if (ds != null)
        {
            return ds;
        }
        else
        {
            return null;
        }
    }
    #endregion

    #region 数据绑定
    public static void BindRepeater(Repeater myRepeater, DataSet ds)
    {
        try
        {
            if (ds != null)
            {
                DataView dv = ds.Tables[0].DefaultView;
                myRepeater.DataSource = dv;
                myRepeater.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion

    #region 拼接List中的值
    public static string GetListValue(List<string> list)
    {
        string fields = string.Empty;
        if (list != null && list.Count > 0)
        {
            foreach (string item in list)
            {
                fields += item + ",";
            }
            if (!string.IsNullOrEmpty(fields) && fields.Length > 0)
            {
                fields = fields.Remove(fields.Length - 1);
            }
            if (!string.IsNullOrEmpty(fields) && fields.Length > 0)
            {
                return fields;
            }
        }
        return string.Empty;
    } 
    #endregion

    #region 拼接dictionary中的值或键
    /// <summary>
    /// 获取dictionary中的值或键
    /// </summary>
    /// <param name="dic"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string GetDictionFieldsOrvalue(Dictionary<string, string> dic, int type)
    {
        string value = string.Empty;
        if (dic != null && dic.Count > 0)
        {
            if (type == 1)
            {
                foreach (string key in dic.Keys)
                {
                    value += key + ",";
                }
            }
            else
            {
                foreach (string key in dic.Values)
                {
                    value += "'" + key+ "',";
                }
            }
        }
        if (!string.IsNullOrEmpty(value) && value.Length > 0)
        {
            value = value.Remove(value.Length - 1);
        }
        return value;
    }
    #endregion

    #region 获取key=value集合 
    public static List<string> GetDictionaryKeyAndValue(Dictionary<string, string> dic)
    {
        List<string> result = new List<string>();
        if (dic != null && dic.Count > 0)
        {
            foreach (string field in dic.Keys)
            {
                string item = string.Empty;
                if (dic.TryGetValue(field, out item))
                {
                    string value = string.Empty;
                    if (item.Contains("-"))
                    {
                         value = field + "=" + item + "";
                    }
                    else if (item.Contains("in"))
                    {
                        value = field+" " + item ;
                    }
                    else
                    {
                        value = field + "='" + item + "'";
                    }
                    result.Add(value);
                }
            }
        }
        if (result!=null && result.Count>0)
        {
            return result;
        }
        else
        {
            return new List<string>();
        }
    } 
    #endregion

    #region 返回值为DBnull的默认值
    /// <summary>  
    /// 返回值为DBnull的默认值  
    /// </summary>  
    /// <param name="typeFullName">数据类型的全称，类如：system.int32</param>  
    /// <returns>返回的默认值</returns>  
    private static object GetDBNullValue(string typeFullName)
    {
        if (typeFullName.Equals(DataType.String, StringComparison.CurrentCultureIgnoreCase))
        {
            return String.Empty;
        }
        if (typeFullName.Equals(DataType.Int32, StringComparison.CurrentCultureIgnoreCase))
        {
            return 0;
        }
        if (typeFullName.Equals(DataType.DateTime, StringComparison.CurrentCultureIgnoreCase))
        {
            return System.DateTime.Now;
        }
        if (typeFullName.Equals(DataType.Boolean, StringComparison.CurrentCultureIgnoreCase))
        {
            return false;
        }
        if (typeFullName.Equals(DataType.Int, StringComparison.CurrentCultureIgnoreCase))
        {
            return 0;
        }
        return null;
    }
    #endregion

    #region 数据类型
    public class DataType
    {
        public static string String = "string";
        public static string Int32 = "int32";
        public static string DateTime = "datetime";
        public static string Boolean = "boolean";
        public static string Int = "int";
    } 
    #endregion

    public static T GetClassInfoAndSetValue<T>(T t,DataSet ds)
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
        if (ds != null && props!=null && props.Length>0)
        {
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                foreach (PropertyInfo item in props)
                {
                    if (item.Name.Equals(ds.Tables[0].Columns[i].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        SetValueOfClass.SetValue(t,item.Name, ds.Tables[0].Rows[0][i].ToString());
                        break;
                    }
                }
           
            }
        }
        return default(T);
    }
}