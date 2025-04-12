using Cognex.VisionPro;
using CommonModels;
using CommonModels.BllModel;
using CommonModels.Enums;
using CommonModels.SystemEntities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.VisionPro;

namespace Vision.CameraPro
{
     public class CameraVisionPro
    {
        private bool LoadSuccessfully = false; 
        private List<CogAcqFifoTool> CogAcqFifoTools = new List<CogAcqFifoTool>();   
        public BllResult InitCamera(List<CameraData> cameraData)
        {
            if(cameraData == null) return BllResultFactory.Error(EmErrorCode.Ev00001.ToString());
            CogFrameGrabbers myFrameGrabbers = new CogFrameGrabbers();

            if (myFrameGrabbers.Count == 0) return BllResultFactory.Error();
            CogAcqFifoTools = new List<CogAcqFifoTool>();

            foreach(var item in cameraData)
            {
                for (int iC = 0; iC < myFrameGrabbers.Count; iC++)
                {
                    if (myFrameGrabbers[iC].SerialNumber == item.SerialNumber)
                    {
                        CogAcqFifoTool cogAcqFifoTool = new CogAcqFifoTool();
                        cogAcqFifoTool.Operator = myFrameGrabbers[iC].CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);
                        CogAcqFifoTools.Add(cogAcqFifoTool);
                    }                  
                }
              
            }
            if (CogAcqFifoTools.Count == 0) return BllResultFactory.Error(EmErrorCode.Ev00002.ToString());
            LoadSuccessfully= true;
            return BllResultFactory.Sucess();
        }

        public CogAcqFifoTool GetCogAcqFifoTool(string serialNumber)
        {
            if (!LoadSuccessfully) return null;

            var result = CogAcqFifoTools.FirstOrDefault(t => t.Operator.FrameGrabber.SerialNumber == serialNumber);
            if (result == null) return null;

            return result;
        }


        public BllResult<Bitmap> GetCogBitmap(string serialNumber)
        {
            var result = CogAcqFifoTools.FirstOrDefault(t => t.Operator.FrameGrabber.SerialNumber == serialNumber);
            if(result == null)   return BllResultFactory<Bitmap>.Error(EmErrorCode.Ev00002.ToString());   

            result.Run();
            return BllResultFactory<Bitmap>.Sucess(result.OutputImage.ToBitmap());   
        }


        public BllResult SetAll(string serialNumber , double exposure, double contrast, double brightness)
        {
            if (!LoadSuccessfully) return BllResultFactory.Error(EmErrorCode.Ev00002.ToString());

            var result = CogAcqFifoTools.FirstOrDefault(t => t.Operator.FrameGrabber.SerialNumber == serialNumber);
            if (result == null) return BllResultFactory.Error(EmErrorCode.Ev00002.ToString());

            if (result.Operator.OwnedExposureParams.Exposure != exposure)
            {
                result.Operator.OwnedExposureParams.Exposure = exposure;
            }
            if (result.Operator.OwnedContrastParams.Contrast != contrast)
            {
                result.Operator.OwnedContrastParams.Contrast = contrast;
            }
            if (result.Operator.OwnedBrightnessParams.Brightness != brightness)
            {
                result.Operator.OwnedBrightnessParams.Brightness = brightness;
            }
            return BllResultFactory.Sucess();
        }

        public BllResult SetExposure(string serialNumber, double exposure)
        {
            if (!LoadSuccessfully) return BllResultFactory.Error(EmErrorCode.Ev00002.ToString());
            var result = CogAcqFifoTools.FirstOrDefault(t => t.Operator.FrameGrabber.SerialNumber == serialNumber);
            if (result == null) return BllResultFactory.Error(EmErrorCode.Ev00002.ToString());

            if (result.Operator.OwnedExposureParams.Exposure != exposure)
            {
                result.Operator.OwnedExposureParams.Exposure = exposure;
            }
            return BllResultFactory.Sucess();
        }
        public BllResult SetContrast(string serialNumber, double contrast)
        {
            if (!LoadSuccessfully) return BllResultFactory.Error(EmErrorCode.Ev00002.ToString());
            var result = CogAcqFifoTools.FirstOrDefault(t => t.Operator.FrameGrabber.SerialNumber == serialNumber);
            if (result == null) return BllResultFactory.Error(EmErrorCode.Ev00002.ToString());

            if (result.Operator.OwnedContrastParams.Contrast != contrast / 100)
            {
                result.Operator.OwnedContrastParams.Contrast = contrast / 100;
            }
            return BllResultFactory.Sucess();
        }
        public BllResult SetBrightness(string serialNumber, double brightness)
        {
            if (!LoadSuccessfully) return BllResultFactory.Error(EmErrorCode.Ev00002.ToString());
            var result = CogAcqFifoTools.FirstOrDefault(t => t.Operator.FrameGrabber.SerialNumber == serialNumber);
            if (result == null) return BllResultFactory.Error(EmErrorCode.Ev00002.ToString());

            if (result.Operator.OwnedBrightnessParams.Brightness != brightness / 100)
            {
                result.Operator.OwnedBrightnessParams.Brightness = brightness / 100;
            }
            return BllResultFactory.Sucess();
        }

        public BllResult UnInit()
        {
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber fg in frameGrabbers)
                fg.Disconnect(false);

            foreach(var item in CogAcqFifoTools)
            {
                item.Operator.Flush();
            }
            return BllResultFactory.Sucess();
        }
    }
}
