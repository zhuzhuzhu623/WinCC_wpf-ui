using CommonModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels.SystemEntities
{
    public  class CameraData : BaseNoSqlEntity
    {
        private string name = "";
        /// <summary>
        ///
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; HandlerPropertyChanged("Name"); }
        }

        private string serialNumber = "";
        /// <summary>
        ///
        /// </summary>
        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; HandlerPropertyChanged("SerialNumber"); }
        }

        private int width = 2592;
        /// <summary>
        ///
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; HandlerPropertyChanged("Width"); }
        }


        private int height = 1944;
        /// <summary>
        ///
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; HandlerPropertyChanged("Height"); }
        }

        public bool Disable { get; set; }

       
    }
}
