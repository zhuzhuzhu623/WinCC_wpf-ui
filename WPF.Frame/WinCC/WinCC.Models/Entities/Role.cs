
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinCC.Model.Entities;
using WinCC.Model.StaticEntities;

namespace WinCC.Model.Entities
{
    [Table(SqlTable.winccRole)]
    public class Role : BaseEntity
    {
        private string roleName;

        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; HandlerPropertyChanged("RoleName"); }
        }

        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; HandlerPropertyChanged("Remark"); }
        }
        private bool disable;

        public bool Disable
        {
            get { return disable; }
            set { disable = value; HandlerPropertyChanged("Disable"); }
        }
    }
}
