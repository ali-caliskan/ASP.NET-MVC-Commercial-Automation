using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradeAutomation.Models.Class
{
    public class Product
    {
        [Key]
        public int ProductsID { get; set; }

        [Display(Name = "Ürün Adı")]
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductsName { get; set; }

        [Display(Name = "Marka")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string  Brand { get; set; }

        [Display(Name = "Stok")]
        public short  Stock { get; set; }

        [Display(Name = "Alış Fiyatı")]
        public decimal BuyPrice { get; set; }

        [Display(Name = "Satış Fiyatı")]
        public decimal SalesPrice { get; set; }

        [Display(Name = "Durum")]
        public bool Status { get; set; }

        [Display(Name = "Ürün Görseli")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<SalesMovement> SalesMovements { get; set; }





    }
}