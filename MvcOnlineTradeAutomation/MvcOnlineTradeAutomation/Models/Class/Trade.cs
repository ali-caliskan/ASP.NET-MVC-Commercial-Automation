using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradeAutomation.Models.Class
{
    public class Trade
    {
        //Cariler
        [Key]
        public int TradeID { get; set; }

        [Display(Name = "Müşteri Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz.")]
        public string TradeName { get; set; }


        [Display(Name = "Müşteri Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz!")]
        public string TradeSurname { get; set; }

        [Display(Name = "Şehir")]
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string TradeCity { get; set; }


        [Display(Name = "E-mail")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TradeMail { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Tradepassword { get; set; }


        public bool Status { get; set; }
        public ICollection<SalesMovement> SalesMovements { get; set; }



    }
}