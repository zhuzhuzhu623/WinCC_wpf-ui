using CommonModels.SystemEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels
{
    public  class SystemSetting
    {
        public int Language { get; set; } = 0;

        public List<CameraData> CameraDatas { get; set; } = new List<CameraData>();  
    }
}
