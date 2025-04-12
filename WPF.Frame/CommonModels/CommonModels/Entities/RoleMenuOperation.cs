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
    [Table(SqlTable.winccRoleMenuoperation)]
    public class RoleMenuOperation:BaseEntity
    {
        [Column("roleId")]
        public int RoleId { get; set; }
        [Column("menuOperationId")]
        public int MenuOperationId { get; set; }
        [Column("visible")]
        public bool Visible { get; set; }

        [Editable(false)]
        public string MenuName { get; set; }
        [Editable(false)]
        public string Url { get; set; }

    }
}
