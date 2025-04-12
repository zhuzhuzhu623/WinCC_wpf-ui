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
    [Table(SqlTable.winccTask)]
    public class TaskEntity:BaseEntity
    {
        private string warehouseId = "";
        /// <summary>
        /// 
        /// </summary>
        public string WarehouseId
        {
            get { return warehouseId; }
            set { warehouseId = value; HandlerPropertyChanged("WarehouseId"); }
        }
        private string warehouseCode = "";
        /// <summary>
        /// 
        /// </summary>
        public string WarehouseCode
        {
            get { return warehouseCode; }
            set { warehouseCode = value; HandlerPropertyChanged("WarehouseCode"); }
        }
        private int type;
        /// <summary>
        /// 
        /// </summary>
        public int Type
        {
            get { return type; }
            set { type = value; HandlerPropertyChanged("Type"); }
        }
        private int sourceLocation;
        /// <summary>
        /// 
        /// </summary>
        public int SourceLocation
        {
            get { return sourceLocation; }
            set { sourceLocation = value; HandlerPropertyChanged("SourceLocation"); }
        }
        private int destinationLocation;
        /// <summary>
        /// 
        /// </summary>
        public int DestinationLocation
        {
            get { return destinationLocation; }
            set { destinationLocation = value; HandlerPropertyChanged("DestinationLocation"); }
        }
        private string containerCode = "";
        /// <summary>
        /// 
        /// </summary>
        public string ContainerCode
        {
            get { return containerCode; }
            set { containerCode = value; HandlerPropertyChanged("ContainerCode"); }
        }
        private string locationCode = "";
        /// <summary>
        /// 
        /// </summary>
        public string LocationCode
        {
            get { return locationCode; }
            set { locationCode = value; HandlerPropertyChanged("LocationCode"); }
        }
        private int lastStatus;
        /// <summary>
        /// 
        /// </summary>
        public int LastStatus
        {
            get { return lastStatus; }
            set { lastStatus = value; HandlerPropertyChanged("LastStatus"); }
        }
        private int status;
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; HandlerPropertyChanged("Status"); }
        }

        [Editable(false)]
        public string StatusDesc {  get { return typeof(EmTaskStatus).GetDescriptionString(Status); } }
        [Editable(false)]
        public string LastStatusDesc { get { return typeof(EmTaskStatus).GetDescriptionString(LastStatus); } } 
        /// <summary>
                                                                                                               /// 任务类型描述
                                                                                                               /// </summary>
        [Editable(false)]
        public string TaskTypeDesc
        {
            get { return typeof(EmTaskType).GetDescriptionString(type); }
        }
    }
}
