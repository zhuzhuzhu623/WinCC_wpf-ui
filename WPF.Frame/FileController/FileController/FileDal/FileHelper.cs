using CommonModels.BllModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileController.FileDal
{
    public class FileHelper
    {
        public static BllResult Save<T>(T t,string path)
        {
            try
            {
                string txtPath = path;
                string result = JsonConvert.SerializeObject(t);
                result = result.Replace(",", ",\r\n");
                File.WriteAllText(txtPath, result);
                return BllResultFactory.Sucess("");
            }
            catch (Exception ex)
            {
                return BllResultFactory.Error(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        public static BllResult<T> Load<T>(string path)
        {
            string txtPath =path;
            //检查路径是否存在该文件，存在则取出来，不存在则赋空值  
            if (File.Exists(txtPath))
            {
                try
                {
                    var resultTxt = File.ReadAllText(txtPath, System.Text.Encoding.UTF8);
                    resultTxt = resultTxt.Replace("\r\n", "");
                    var result = JsonConvert.DeserializeObject<T>(resultTxt);
                    if (result == null)
                        return BllResultFactory<T>.Error("配置文件解析失败");
                    return BllResultFactory<T>.Sucess(result);
                }
                catch (Exception ex)
                {
                    return BllResultFactory<T>.Error(ex.Message + "\r\n" + ex.StackTrace);
                }
            }
            else
            {
                return BllResultFactory<T>.Error("未找到配置文件");
            }
        }
    }
}
