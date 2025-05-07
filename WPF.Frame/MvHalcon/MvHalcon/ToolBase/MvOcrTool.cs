using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvHalcon.ToolBase
{
    /// <summary>
    /// 字符类型   白纸黑字|黑纸白字
    /// </summary>
    public enum CharType
    {
        BlackChar,
        WhiteChar,
    }
    public class MvOcrTool : MvToolBase
    { 
        /// 字符类型，白纸黑字或黑纸白字
       /// </summary>
        public CharType charType = CharType.BlackChar;
        /// <summary>
        /// 标准字符列表
        /// </summary>
        public string standardCharList = string.Empty;

        /// <summary>
        /// 字符模板句柄
        /// </summary>
        public HTuple modelID = -1;
        /// <summary>
        /// 字符模板区域
        /// </summary>
        public HObject templateRegion;
        /// <summary>
        /// 感兴趣区域
        /// </summary>
        public HObject imageReduced;

        /// <summary>
        /// 做模板时的标准图像
        /// </summary>
        internal HObject standardImage;

        /// <summary>
        /// 搜索区域
        /// </summary>
        public HObject searchRegion;

        /// <summary>
        /// 模板是否已创建
        /// </summary>
        public bool isCreated = false;
        /// <summary>
        /// 输入图像
        /// </summary>
        public HObject inputImage;

        /// <summary>
        /// 分割阈值
        /// </summary>
        public int threshold = 128;

        /// <summary>
        /// 膨胀单元数
        /// </summary>
        public int dilationSize = 1;

        /// <summary>
        /// 训练字符
        /// </summary>
        public void Train()
        {
            try
            {
                if (templateRegion != null)
                {
                    //HOperatorSet.SetColor(Frm_ImageWindow.Instance.WindowHandle, new HTuple("green"));
                    //HOperatorSet.DispObj(templateRegion, Frm_ImageWindow.Instance.WindowHandle);
                }
                else
                {
                    return ;
                }
              
                HOperatorSet.ReduceDomain(inputImage, templateRegion, out imageReduced);

                //Bitmap bitmap = new Bitmap(HobjectToBitmap24(imageReduced));
                //bitmap.Save("D:\\VisionProImage\\OCR1-1.jpg");
                HObject region;
                if (charType == CharType.BlackChar)
                    HOperatorSet.Threshold(imageReduced, out region, 0, threshold);
                else
                    HOperatorSet.Threshold(imageReduced, out region, threshold, 255);
                HObject ConnectedRegions;
                HOperatorSet.Connection(region, out ConnectedRegions);
                HObject SelectedRegions;
                HOperatorSet.SelectShape(ConnectedRegions, out SelectedRegions, new HTuple("area"), "and", 10, 99999);
                HObject RegionUnion1;
                HOperatorSet.Union1(SelectedRegions, out RegionUnion1);
                HObject RegionDilation;
                if (dilationSize > 0)
                    HOperatorSet.DilationCircle(RegionUnion1, out RegionDilation, dilationSize);
                else
                    RegionDilation = RegionUnion1;
                HObject RegionUnion;
                HOperatorSet.Union1(RegionDilation, out RegionUnion);
                HObject ConnectedRegions1;
                HOperatorSet.Connection(RegionUnion, out ConnectedRegions1);
                HObject SortedRegions;
                HOperatorSet.SortRegion(ConnectedRegions1, out SortedRegions, "character", "true", "column");
                //////HOperatorSet.SetColored(Frm_ImageWindow .Instance .WindowHandle ,new HTuple ( 20));
                //HOperatorSet.SetColor(Frm_ImageWindow.Instance.WindowHandle, new HTuple("orange"));
                //HOperatorSet.DispObj(SortedRegions, Frm_ImageWindow.Instance.WindowHandle);
                HTuple charArray = StringToHTupleList(standardCharList);
                try
                {
                    HOperatorSet.WriteOcrTrainf(SortedRegions, imageReduced, charArray, "train_ocr");
                }
                catch(Exception ex)
                {                  
                    return;
                }

                HTuple CharacterNames, CharacterCount;
                HOperatorSet.ReadOcrTrainfNames("train_ocr", out CharacterNames, out CharacterCount);
                HOperatorSet.CreateOcrClassMlp(8, 10, "constant", "default", CharacterNames, 80, "none", 10, 42, out modelID);
                HTuple Error, ErrorLog;
                HOperatorSet.TrainfOcrClassMlp(modelID, "train_ocr", 100, 0.01, 0.01, out Error, out ErrorLog);

                isCreated= true;
            }
            catch (Exception ex)
            {
                
            }
        }


        /// <summary>
        /// 运行工具
        /// </summary>
        /// <param name="updateImage">是否刷新图像</param>
        public void Run()
        {
            try
            {
                if (inputImage == null)
                {
                    return;
                }
                if (!isCreated)
                {
                    return;
                }

                HOperatorSet.ReduceDomain(standardImage, searchRegion, out imageReduced);
                HObject region;
                HOperatorSet.Threshold(imageReduced, out region, 0, 128);
                HObject ConnectedRegions;
                HOperatorSet.Connection(region, out ConnectedRegions);
                HObject SelectedRegions;
                HOperatorSet.SelectShape(ConnectedRegions, out SelectedRegions, new HTuple("area"), "and", 10, 99999);
                HObject RegionUnion1;
                HOperatorSet.Union1(SelectedRegions, out RegionUnion1);
                HObject RegionDilation;
                HOperatorSet.DilationCircle(RegionUnion1, out RegionDilation, 1);
                HObject RegionUnion;
                HOperatorSet.Union1(RegionDilation, out RegionUnion);
                HObject ConnectedRegions1;
                HOperatorSet.Connection(RegionUnion, out ConnectedRegions1);
                HObject RegionIntersection;
                HOperatorSet.Intersection(ConnectedRegions1, RegionUnion1, out RegionIntersection);
                HObject SortedRegions;
                HOperatorSet.SortRegion(RegionIntersection, out SortedRegions, "character", "true", "column");

                HTuple charList = new HTuple();
                HTuple confidence = new HTuple();
                try
                {
                    HOperatorSet.DoOcrMultiClassMlp(SortedRegions, imageReduced, modelID, out charList, out confidence);
                }
                catch
                {
                    Train();        //程序重启句柄会失效，需要重新训练字符
                }

                string result = string.Empty;
                for (int i = 0; i < charList.Length; i++)
                {
                    result += charList[i];
                }


            }
            catch (Exception ex)
            {
            }
        }

        public void SetRoi()
        {
            HTuple row = 0, column = 0, row1 = 300, column1 = 300;
            HObject rectangle1;
            HOperatorSet.GenRectangle1(out rectangle1, row, column, row1, column1);
            searchRegion = rectangle1;
        }

        /// <summary>
        /// 将字符串转化为HTuple类型的数组
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns></returns>
        internal HTuple StringToHTupleList(string str)
        {
            try
            {
                HTuple hv_Len;
                HOperatorSet.TupleStrlen(str, out hv_Len);
                HTuple hv_chararray = new HTuple();
                HTuple end_val6 = hv_Len - 1;
                HTuple step_val6 = 1;
                for (int hv_i = 0; hv_i < str.Length; hv_i++)
                {

                    HTuple hv_Selected;
                    HOperatorSet.TupleStrBitSelect(str, hv_i, out hv_Selected);

                    HTuple
                      ExpTmpLocalVar_chararray = hv_chararray.TupleConcat(
                        hv_Selected);

                    hv_chararray = ExpTmpLocalVar_chararray;
                }
                return hv_chararray;
            }
            catch (Exception ex)
            {
                return new HTuple();
            }
        }
    }
}
