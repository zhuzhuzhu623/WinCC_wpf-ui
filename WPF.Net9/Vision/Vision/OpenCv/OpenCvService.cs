using CommonModels.BllModel;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.VisionPro.Common.Entitis;

namespace Vision.OpenCv
{
    public class OpenCvService 
    {
        public  BllResult<int> MatchTemplate(string tempName, string waferName, double score)
        {
            try
            {
                tempName = "C:\\Users\\Administrator\\Desktop\\pictures\\1.png";
                waferName = "C:\\Users\\Administrator\\Desktop\\pictures\\Pic_2023_03_21_143441_1.bmp";


                Bitmap bitmap =null;
                Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);

                // 读取原始图像和模板图像
                Mat srcImg = Cv2.ImRead(waferName, ImreadModes.AnyDepth);
                Mat templateImg = Cv2.ImRead(tempName, ImreadModes.AnyDepth);

                // 定义结果矩阵
                Mat resultImg = new Mat();

                // 模板匹配
                Cv2.MatchTemplate(srcImg, templateImg, resultImg, TemplateMatchModes.CCoeffNormed);

                // 查找匹配结果的最大值和位置
                double minVal, maxVal;
                Point minLoc, maxLoc;
                Cv2.MinMaxLoc(resultImg, out minVal, out maxVal, out minLoc, out maxLoc);

                // 在原始图像上绘制矩形框
                Cv2.Rectangle(srcImg, new Rect(maxLoc, new Size(templateImg.Cols, templateImg.Rows)), new Scalar(255, 0, 255), 2);

                // 显示结果图像
                Cv2.ImShow("Result", srcImg);
                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();

                if (maxVal < score)
                {
                    return BllResultFactory<int>.Error(-1, "评分低于设定值");
                }
                return BllResultFactory<int>.Sucess(1);
            }
            catch (Exception ex)
            {
                return BllResultFactory<int>.Error(-1, ex.Message.ToString());
            }

        }

        public BllResult<int> MatchTemplate(MatchingTrain templateEntity, string waferName, double score)
        {
            try
            {
                //Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(templateEntity.Bitmap);

                //Rect rect = new Rect(templateEntity.StartX, templateEntity.StartY, templateEntity.Width, templateEntity.Height);
                //imgTemplate = mat[rect];
                //// 读取原始图像和模板图像
                //Mat srcImg = Cv2.ImRead(waferName, ImreadModes.AnyDepth);
                //Mat templateImg = Cv2.ImRead(tempName, ImreadModes.AnyDepth);

                //// 定义结果矩阵
                //Mat resultImg = new Mat();

                //// 模板匹配
                //Cv2.MatchTemplate(srcImg, templateImg, resultImg, TemplateMatchModes.CCoeffNormed);

                //// 查找匹配结果的最大值和位置
                //double minVal, maxVal;
                //Point minLoc, maxLoc;
                //Cv2.MinMaxLoc(resultImg, out minVal, out maxVal, out minLoc, out maxLoc);

                //// 在原始图像上绘制矩形框
                //Cv2.Rectangle(srcImg, new Rect(maxLoc, new Size(templateImg.Cols, templateImg.Rows)), new Scalar(255, 0, 255), 2);

                //// 显示结果图像
                //Cv2.ImShow("Result", srcImg);
                //Cv2.WaitKey(0);
                //Cv2.DestroyAllWindows();

               // if (maxVal < score)
                {
                    return BllResultFactory<int>.Error(-1, "评分低于设定值");
                }
                return BllResultFactory<int>.Sucess(1);
            }
            catch (Exception ex)
            {
                return BllResultFactory<int>.Error(-1, ex.Message.ToString());
            }

        }

        public BllResult<int> Canny()
        {
            try
            {
                string tempName = "C:\\Users\\Administrator\\Desktop\\pictures\\Pic_2023_03_21_165144_6.bmp";
                Mat srcImg = Cv2.ImRead(tempName, ImreadModes.Color);
                Mat grayImg = new Mat();
                Cv2.CvtColor(srcImg, grayImg, ColorConversionCodes.BGR2GRAY);
                Mat blurImg = new Mat();
                Cv2.GaussianBlur(grayImg, blurImg, new Size(3, 3), 0);
                Mat cannyImg = new Mat();
                Cv2.Canny(blurImg, cannyImg, 100, 200);
                Cv2.ImShow("Canny Edge Detection", cannyImg);
                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();

                return BllResultFactory<int>.Sucess(1);
            }
            catch (Exception ex)
            {
                return BllResultFactory<int>.Error(-1, ex.Message.ToString());
            }

        }

        public BllResult<int> FindContours()
        {
            try
            {
                string tempName = "C:\\Users\\Administrator\\Desktop\\pictures\\Pic_2023_03_21_165144_6.bmp";
                Mat image = Cv2.ImRead(tempName, ImreadModes.AnyDepth);
                Mat binary = new Mat();
                Cv2.Threshold(image, binary, 0, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);
                Point[][] contours;
                HierarchyIndex[] hierarchy;
                Cv2.FindContours(binary, out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
                for (int i = 0; i < contours.Length; i++)
                {
                    Rect rect = Cv2.BoundingRect(contours[i]);
                    if (rect.Width > 10 && rect.Height > 10 && rect.Width < 100 && rect.Height < 100)
                    {
                        Cv2.DrawContours(image, contours, i, Scalar.Red, 2);
                    }
                }
                Cv2.ImShow("Result", image);
                Cv2.WaitKey();
                return BllResultFactory<int>.Sucess(1);
            }
            catch (Exception ex)
            {
                return BllResultFactory<int>.Error(-1, ex.Message.ToString());
            }
        }

    }

}

