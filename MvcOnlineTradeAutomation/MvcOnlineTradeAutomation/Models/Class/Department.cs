using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradeAutomation.Models.Class
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Display(Name = "Departman Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        public bool Status { get; set; }
        public ICollection<Personnel> Personnels { get; set; }
        
    }
}