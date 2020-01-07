using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class TablaViewModel
    {

        public int Id { get; set; }
        public int IdType { get; set; }
        public int IdColor { get; set; }
        public int IdBrand { get; set; }
        public int IdProvider { get; set; }
        public int IdCatalog { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Name of Shoe")]
        public string Nombre { get; set; }
        public string Description { get; set; }
        public string Observations { get; set; }
        public decimal PriceDistributor { get; set; }
        public decimal PriceClient { get; set; }
        public decimal PriceMember { get; set; }
        public bool IsEnabled { get; set; }
        public string Keywords { get; set; }
        //[Required]
        //[DataType(DataType.DateTime)]
        //[Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime DateTime{ get; set; }
    }
}