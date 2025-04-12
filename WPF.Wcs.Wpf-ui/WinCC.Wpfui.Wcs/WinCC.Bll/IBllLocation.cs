using CommonModels.BllModel;
using CommonModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinCC.Bll.Entities;

namespace WinCC.Bll
{
    public interface IBllLocation
    {
        Task<BllResult<List<Location>>> GetLocation();

        Task<BllResult> CreateLocation(CreateLocationData createLocationData);
    }
}
