using CommonModels.StaticEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonModels.Entities
{
    [Table(SqlTable.winccLogContent)]
    public class LogContent : BaseEntity
    {
        private string logLevel = "";
        /// <summary>
        /// 
        /// </summary>
        public string LogLevel
        {
            get { return logLevel; }
            set { logLevel = value; HandlerPropertyChanged("LogLevel"); }
        }
        private string description = "";
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; HandlerPropertyChanged("Description"); }
        }
        private string content = "";
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; HandlerPropertyChanged("Content"); }
        }

        [Editable(false)]
        public string DateTime { get; set; }
        

        [Editable(false)]
        public string LogViewTime { get; set; }

       // [Editable(false)]
       // public Color LogColor { get; set; }
       
    }
}
