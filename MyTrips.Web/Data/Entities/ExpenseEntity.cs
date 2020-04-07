using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrips.Web.Data.Entities
{
    public class ExpenseEntity
    {
        public int Id { get; set; }

        [Display(Name = "Amount")]
        public int Amount { get; set; } //Cost

        [Display(Name = "Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.DateTime)]       
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm tt}")]
        public DateTime StartDateLocal => StartDate.ToLocalTime();

        //TODO Donde Guardo las imagenes?
        [Display(Name = "PicturePath")]
        public string PicturePath { get; set; }

        public ExpenseTypeEntity ExpenseType { get; set; }

        public TripEntity Trip { get; set; }
    }
}
