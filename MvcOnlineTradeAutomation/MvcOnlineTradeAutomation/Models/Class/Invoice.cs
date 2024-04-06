using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradeAutomation.Models.Class
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [Display(Name = "Fatura Seri Numarası")]
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSeriNo { get; set; }

        [Display(Name = "Fatura Sıra Numarası")]
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceSıraNo { get; set; }

        [Display(Name = "Tarih")]
        public DateTime  Date { get; set; }


        [Display(Name = "Vergi Dairesi")]
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxOffice { get; set; }


        [Display(Name = "Saat")]
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Clock { get; set; }


        [Display(Name = "Teslim Eden Kişi")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Deliveredby { get; set; } //Teslim Eden


        [Display(Name = "Teslim Alan Kişi")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set; } //Teslim Alan 


        public decimal Total { get; set; }

        public ICollection<InvoicePen> InvoicePens { get; set; }
        
    }
}