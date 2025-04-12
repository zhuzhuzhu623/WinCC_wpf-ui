using CommonModels.Enums;
using CommonModels.EnumsExtends;
using CommonModels.StaticEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels.Entities
{
    [Table(SqlTable.winccLocation)]
    public class Location:BaseEntity
    {


        /// <summary>
        /// 库位编码
        /// </summary>
        public string Code { get; set; }    
       
        private int row;
        /// <summary>
        /// 行
        /// </summary>
        public int Row
        {
            get { return row; }
            set { row = value; HandlerPropertyChanged("Row"); }
        }
        private int column;
        /// <summary>
        /// 列
        /// </summary>
        public int Column
        {
            get { return column; }
            set { column = value; HandlerPropertyChanged("Column"); }
        }
        private int layer;
        /// <summary>
        /// 层
        /// </summary>
        public int Layer
        {
            get { return layer; }
            set { layer = value; HandlerPropertyChanged("Layer"); }
        }
        private int type;
        /// <summary>
        /// 库位类型
        /// </summary>
        public int Type
        {
            get { return type; }
            set { type = value; HandlerPropertyChanged("Type"); }
        }



        private int status;
        /// <summary>
        /// 状态
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; HandlerPropertyChanged("Status"); }
        }

         private string containerCode = "";
        /// <summary>
        /// 当前条码
        /// </summary>
        public string ContainerCode
        {
            get { return containerCode; }
            set { containerCode = value; HandlerPropertyChanged("ContainerCode"); }
        }

        private string wareHouseCode="";
        /// <summary>
        /// 仓库编码
        /// </summary>
        public string WareHouseCode
        {
            get { return wareHouseCode; }
            set { wareHouseCode = value; HandlerPropertyChanged("WareHouseCode"); }
        }


        /// <summary>
        /// 当前状态
        /// </summary>
        [Editable(false)]
        public string StatusCode
        {
            get { return typeof(EmLocationStatus).GetDescriptionString(Status); }
        }
    }
}
