using GM.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GM.Translate
{
    public  class BaiduTranslate
    {
        public string GetContext(FlieText flieText)
        {
            // 原文
            string q = flieText.Context;
            // 源语言
            string from = ((EmLanguageType)flieText.From).ToString();
            // 目标语言
            string to = ((EmLanguageType)flieText.To).ToString();
            // 改成您的APP ID
            string appId = "20240527002062842";
            Random rd = new Random();
            string salt = rd.Next(100000).ToString();
            // 改成您的密钥
            string secretKey = "MFZ2lxuXljE5C_yAZnir";
            string sign = EncryptString(appId + q + salt + secretKey);
            string url = "http://api.fanyi.baidu.com/api/trans/vip/translate?";
            url += "q=" + q;
            url += "&from=" + from;
            url += "&to=" + to;
            url += "&appid=" + appId;
            url += "&salt=" + salt;
            url += "&sign=" + sign;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = 6000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            var dataResult = JsonConvert.DeserializeObject<ResultPram>(retString);
            if (dataResult == null) return "";
            if (dataResult.trans_result == null) return "";
            return dataResult.trans_result[0].dst;
        }
        // 计算MD5值
        public static string EncryptString(string str)
        {
            MD5 md5 = MD5.Create();
            // 将字符串转换成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            // 调用加密方法
            byte[] byteNew = md5.ComputeHash(byteOld);
            // 将加密结果转换为字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                // 将字节转换成16进制表示的字符串，
                sb.Append(b.ToString("x2"));
            }
            // 返回加密的字符串
            return sb.ToString();
        }
    }
    public class FlieText
    {
        public string Context { get; set; }

        public string AllContext { get; set; }
        public string ResultContext { get; set; }
        public int From { get; set; }   
        public int To { get; set; } 
    }
    public class ResultPram
    {
        public string q { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public DataResult[] trans_result { get; set; }
        public int error_code { get; set; }
    }

    public class DataResult
    {
        public string src { get; set; }
        public string dst { get; set; }
    }
}
