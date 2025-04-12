using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLLModel
{
    public static class Extends
    {
        #region Enum
        /// <summary>
        /// 获取枚举成员的值(this是扩展方法的标志)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetIndexInt(this Enum obj)
        {
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 获取枚举成员的值(this是扩展方法的标志)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetIndexString(this Enum obj)
        {
            return Convert.ToInt32(obj).ToString();
        }


        public static T ToEnum<T>(this string obj) where T : struct
        {
            if (string.IsNullOrEmpty(obj))
            {
                return default(T);
            }
            try
            {
                return (T)Enum.Parse(typeof(T), obj, true);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 获取指定枚举成员的描述
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToDescriptionString(this Enum obj)
        {
            var attribs = (DescriptionAttribute[])obj.GetType().GetField(obj.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attribs.Length > 0 ? attribs[0].Description : obj.ToString();
        }

        /// <summary>
        /// 根据枚举值，获取指定枚举类的成员描述
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetDescriptionString(this Type type, int? id)
        {
            var values = from Enum e in Enum.GetValues(type)
                         select new { id = e.GetIndexInt(), name = e.ToDescriptionString() };

            if (!id.HasValue) id = 0;

            try
            {
                return values.ToList().Find(c => c.id == id).name;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 根据枚举获取描述
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetDescriptionFromEnum(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] info = type.GetMember(en.ToString());
            if (info != null && info.Length > 0)
            {
                object[] obj = info[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (obj != null && obj.Length > 0)
                    return ((DescriptionAttribute)obj[0]).Description;
            }
            return en.ToString();
        }

        #endregion
    }
}
