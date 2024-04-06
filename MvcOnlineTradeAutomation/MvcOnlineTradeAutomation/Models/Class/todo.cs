using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradeAutomation.Models.Class
{
    public class todo
    {
        [Key]
        public int TodoID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string title { get; set; }

        [Column(TypeName = "bit")]
        public bool durum { get; set; }

    }
}