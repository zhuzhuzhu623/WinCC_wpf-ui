using CommonModels.StaticEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonModels.Entities;

namespace CommonModels.Entities
{
    [Table(SqlTable.winccPlcParameters)]
    public class PlcParameters : BaseEntity
    {
        private int address;
        public int Address
        {
            get { return address; }
            set { address = value; HandlerPropertyChanged("Address"); }
        }
        private string functionName = "";
        public string FunctionName
        {
            get { return functionName; }
            set { functionName = value; HandlerPropertyChanged("FunctionName"); }
        }
        private bool isBit;
        public bool IsBit
        {
            get { return isBit; }
            set { isBit = value; HandlerPropertyChanged("IsBit"); }
        }
        private int bitNumber;
        public int BitNumber
        {
            get { return bitNumber; }
            set { bitNumber = value; HandlerPropertyChanged("BitNumber"); }
        }
        private int addValue;
        public int AddValue
        {
            get { return addValue; }
            set { addValue = value; HandlerPropertyChanged("AddValue"); }
        }
        private string unit = "";
        public string Unit
        {
            get { return unit; }
            set { unit = value; HandlerPropertyChanged("Unit"); }
        }

        private int functionType;
        public int FunctionType
        {
            get { return functionType; }
            set { functionType = value; HandlerPropertyChanged("FunctionType"); }
        }
    }
}
