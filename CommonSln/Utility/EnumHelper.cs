using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CCLUtility
{
    public class EnumHelper
    {
        public static string GetDes(Enum enumValue)
        {
            if (enumValue == null)
                return StringExtend.GetNAStr();
            //获取类型
            var enumType = enumValue.GetType();
            //获取字段信息
            var field = enumType.GetField(enumValue.ToString());
            if(field!=null)
            {
                var attributes = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                return attributes.Description;
            }
            return StringExtend.GetNAStr();
        }
    }
}
