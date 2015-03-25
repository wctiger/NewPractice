using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    [Table("dbo.tblUsers")]
    public class User
    {
        [Key]
        [Column(Order=0)]
        public int UserID { get; set; }

        [Required]
        [Column(Order=1)]
        public string UserName { get; set; }

        [Required]
        [Column(Order=2)]
        public string Password { get; set; }

        [Column(Order=3)]
        public Guid UserGuid { get; set; }
    }
}
