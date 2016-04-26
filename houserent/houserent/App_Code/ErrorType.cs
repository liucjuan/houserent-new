using BirdSof;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;

namespace Error
{
    /// <summary>
    /// ErrorType 的摘要说明
    /// </summary>
    public enum ErrorType
    {
        [EnumDescription("成功")]
        Success = 0000,

        [EnumDescription("失败")]
        Failed = 0001,

        [EnumDescription("当前用户不存在")]
        BadUser = 0002,

        [EnumDescription("密码有误")]
        BadPassWord = 0003,

        [EnumDescription("where条件有误")]
        BadWhere = 0004,

        [EnumDescription("数据更新参数有误")]
        BadUpdate = 0005,
    }
}


// string txt = EnumDescription.GetFieldText(ErrorType.BadPassWord);
