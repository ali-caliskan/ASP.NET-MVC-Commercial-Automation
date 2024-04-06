using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradeAutomation.Models.Class
{
    public class Expense
    {
        [Key]
        public int ExpensesID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string EDescription { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}