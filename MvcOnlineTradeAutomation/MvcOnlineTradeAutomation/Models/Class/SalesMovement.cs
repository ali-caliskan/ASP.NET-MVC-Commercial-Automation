using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTradeAutomation.Models.Class
{
    public class SalesMovement
    {
        [Key]
        public int SalesID { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Miktar")]
        public int quantity { get; set; }

        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Display(Name = "Toplam Tutar")]
        public decimal TotalAmount { get; set; }

        public int ProductsID { get; set; }
        public int TradeID { get; set; }
        public int PersonnelID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Trade Trade { get; set; }
        public virtual Personnel Personnel { get; set; }
        



    }
}