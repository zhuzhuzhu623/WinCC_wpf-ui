using CommonModels.BllModel;
using CommonModels.Entities;
using FileController.DapperDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinCC.Bll.Entities;

namespace WinCC.Bll.BllService
{
    public   class LocationService:IBllLocation
    {
        private IDapper _dapper;
        public LocationService(IDapper dapper)        
        {
            _dapper = dapper;
        }        


        public async Task<BllResult<List<Location>>> GetLocation()
        {
           var result =await  _dapper.GetCommonModelByConditionAsync<Location>("");       
            return result;
        }

        public async Task<BllResult> CreateLocation(CreateLocationData createLocationData)
        {
            _dapper.ExcuteCommonSqlForInsertOrUpdate("TRUNCATE TABLE winccLocation");

            List<Location> locations = new List<Location>();

            for (int r = 1; r < createLocationData.Row + 1; r++)
            {
                for (int c = 1; c < createLocationData.Column + 1; c++)
                {
                    for (int l = 1; l < createLocationData.Column + 1 ; l++)
                    {
                        Location location = new Location();
                        location.Code = $"L-{r}-{c}-{l}";
                        location.Row = r;
                        location.Column = c;
                        location.Layer = l;
                        location.Status = 0;
                       var resultSave = _dapper.SaveCommonModel(location);
                        if (!resultSave.Success) return BllResultFactory.Error();
                    }
                }
            }
            return BllResultFactory.Sucess();
        }
    }
}
