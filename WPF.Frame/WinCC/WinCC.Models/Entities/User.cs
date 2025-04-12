
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinCC.Model.Entities;
using WinCC.Model.Enums;
using WinCC.Model.EnumsExtends;
using WinCC.Model.StaticEntities;

namespace WinCC.Model.Entities
{
    [Table(SqlTable.winccUser)]
    public class User : BaseEntity
    {

        [Column("userName")]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }

        [Column("roleId")]
        public int RoleId { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("remark")]
        public string Remark { get; set; }

        [Column("disable")]
        public bool Disable { get; set; }

        [Editable(false)]
        public List<Role> Roles { get; set; }

        [Editable(false)]
        public bool IsChecked { get; set; }

        [Editable(false)]
        public string RoleName
        {
            get
            {
                return typeof(EmRoleType).GetDescriptionString(RoleId);
            }
        }
    }
}
