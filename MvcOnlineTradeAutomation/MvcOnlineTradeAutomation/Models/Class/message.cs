using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradeAutomation.Models.Class
{
    public class message
    {
        [Key]
        public int MessageID { get; set; }

        [Display(Name = "Gönderici")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Sender { get; set; }


        [Display(Name = "Alıcı")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string buyer { get; set; }

        [Display(Name = "Konu")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Subject { get; set; }

        [Display(Name = "İçerik")]
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Contents { get; set; }

        [Display(Name = "Tarih")]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
    }
}