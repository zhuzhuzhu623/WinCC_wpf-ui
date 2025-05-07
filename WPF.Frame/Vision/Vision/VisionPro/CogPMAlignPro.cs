using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using CommonModels.BllModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Common.EntitisResult;
using Vision.VisionPro.Common.Entitis;

namespace Vision.VisionPro
{
    public class CogPMAlignPro
    {
        /// <summary>
        /// 模板匹配
        /// </summary>
        private CogPMAlignTool PMAlignTool = new CogPMAlignTool();

        public CogPMAlignPro() 
        {
            //设置角度值
            PMAlignTool.RunParams.ZoneAngle.High = Math.PI / 4;
            PMAlignTool.RunParams.ZoneAngle.Low = -Math.PI / 4;
            PMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
        }


        /// <summary>
        /// 单模板训练
        /// </summary>
        /// <param name="templateEntity"></param>
        /// <returns></returns>
        public BllResult Train(MatchingTrain templateEntity)
        {
            PMAlignTool.InputImage = new CogImage8Grey(templateEntity.Bitmap);
            PMAlignTool.Pattern.TrainImage = PMAlignTool.InputImage;

            if (templateEntity.EmTargetType == Vision.Common.Enums.EmTargetType.Circle)
            {
                CogCircle crl = new CogCircle();

                crl.CenterX = templateEntity.StartX / 2;
                crl.CenterY = templateEntity.StartY / 2;

                crl.Radius = templateEntity.Width / 2;
                PMAlignTool.Pattern.TrainRegion = crl;
                PMAlignTool.Pattern.Origin.TranslationX = crl.CenterX;
                PMAlignTool.Pattern.Origin.TranslationY = crl.CenterY;
            }
            else
            {
                CogRectangle r = new CogRectangle();

                r.Width = templateEntity.Width;
                r.X = templateEntity.StartX;

                r.Height = templateEntity.Height;
                r.Y = templateEntity.StartY;

                PMAlignTool.Pattern.TrainRegion = r;
                PMAlignTool.Pattern.Origin.TranslationX = r.CenterX;
                PMAlignTool.Pattern.Origin.TranslationY = r.CenterY;
            }

            PMAlignTool.Pattern.Train();
            if (!PMAlignTool.Pattern.Trained)
            {
                return BllResultFactory.Error("模板匹配训练失败");
            }
            return BllResultFactory.Sucess("");
        }
        /// <summary>
        /// 模板匹配运行参数
        /// </summary>
        /// <param name="mathcingRun"></param>
        public void SetMathcingRun(MathcingRun mathcingRun)
        {
            CogRectangle searchR = new CogRectangle();
            searchR.X = mathcingRun.SearchStartX;
            searchR.Y = mathcingRun.SearchStartY;
            searchR.Width = mathcingRun.SearchWidth;
            searchR.Height = mathcingRun.SearchHeight;
            PMAlignTool.RunParams.AcceptThreshold = mathcingRun.Score;
            PMAlignTool.SearchRegion = searchR;
        }

        /// <summary>
        /// 单模板匹配
        /// </summary>
        /// <param name="mathcingRun"></param>
        /// <returns></returns>
        public BllResult<List<MatchingResult>> Run(Bitmap bitmap)
        {
            PMAlignTool.InputImage = new CogImage8Grey(bitmap);
            PMAlignTool.Run();
            if (PMAlignTool.RunStatus.Result == CogToolResultConstants.Error)
            {
                return BllResultFactory<List<MatchingResult>>.Error(null, "未匹配到模板");
            }
            if (PMAlignTool.Results.Count == 0)
                return BllResultFactory<List<MatchingResult>>.Error(null, "未匹配到模板");
            List<MatchingResult> matchingResults = new List<MatchingResult>();
            for (int i = 0; i < PMAlignTool.Results.Count; i++)
            {
                CogPMAlignResult result = PMAlignTool.Results[i];
                var resultX = Math.Round(result.GetPose().TranslationX, 4);
                var resultY = Math.Round(result.GetPose().TranslationY, 4);
                var resultAngle = Math.Round(result.GetPose().Rotation, 4);

                matchingResults.Add(new MatchingResult() { X = resultX, Y = resultY, Angle = resultAngle });
            }
            return BllResultFactory<List<MatchingResult>>.Sucess(matchingResults, "");
        }
    }
}
