using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradeAutomation.Models.Class
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Statement { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingCode {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Personnel {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string Buyer {  get; set; }
        public DateTime Date {  get; set; }


    }
}