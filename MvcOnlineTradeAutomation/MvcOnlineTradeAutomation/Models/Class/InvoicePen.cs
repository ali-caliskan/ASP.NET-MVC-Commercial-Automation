using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradeAutomation.Models.Class
{
    public class InvoicePen
    {
        [Key]
        public int InvoicePenID { get; set; }

        [Display(Name = "Açıklama")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }

        [Display(Name = "Miktar")]
        public int Quantity { get; set; }

        [Display(Name = "Birim Fiyatı")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Toplam Tutar")]
        public decimal Amount { get; set; }

        public int Invoiceid { get; set; }
        public virtual Invoice Invoices { get; set; }

        

    }
}