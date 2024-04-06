using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradeAutomation.Models.Class
{
    public class Personnel
    {
        [Key]
        public int PersonnelID { get; set; }


        [Display(Name = "Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonnelName { get; set; }

        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonnelSurname { get; set; }

        [Display(Name = "Personel Görsel")]
        //Görselin kendisi değil optimizasyon için sadece yolunu tutmak için string kullandık.
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Personnelİmage { get; set; }

        public ICollection<SalesMovement> SalesMovements { get; set; }

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        


    }
}