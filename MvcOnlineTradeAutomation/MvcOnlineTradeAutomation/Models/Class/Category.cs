using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradeAutomation.Models.Class
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Display(Name = "Kategori Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}