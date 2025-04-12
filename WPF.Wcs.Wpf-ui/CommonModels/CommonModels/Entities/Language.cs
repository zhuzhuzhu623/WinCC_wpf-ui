using CommonModels.StaticEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels.Entities
{
    [Table(SqlTable.winccLanguage)]
    public class Language:BaseEntity
    {
        private string chinese ="";
        /// <summary>
        /// 中文
        /// </summary>
        public string Chinese
        {
            get { return chinese; }
            set { chinese = value; HandlerPropertyChanged("Chinese"); }
        }
        private string english = "";
        /// <summary>
        /// 英语
        /// </summary>
        public string English
        {
            get { return english; }
            set { english = value; HandlerPropertyChanged("English"); }
        }
        private string russian = "";
        /// <summary>
        /// 俄语
        /// </summary>
        public string Russian
        {
            get { return russian; }
            set { russian = value; HandlerPropertyChanged("Russian"); }
        }
        private string arabic = "";
        /// <summary>
        /// 阿拉伯语
        /// </summary>
        public string Arabic
        {
            get { return arabic; }
            set { arabic = value; HandlerPropertyChanged("Arabic"); }
        }
        private string spanish = "";
        /// <summary>
        /// 西班牙语
        /// </summary>
        public string Spanish
        {
            get { return spanish; }
            set { spanish = value; HandlerPropertyChanged("Spanish"); }
        }
        private string french = "";
        /// <summary>
        /// 西班牙语
        /// </summary>
        public string French
        {
            get { return french; }
            set { french = value; HandlerPropertyChanged("French"); }
        }
        private string german = "";
        /// <summary>
        /// 西班牙语
        /// </summary>
        public string German
        {
            get { return german; }
            set { german = value; HandlerPropertyChanged("German"); }
        }
    }
}
