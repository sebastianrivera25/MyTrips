using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTrips.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace MyTrips.Web.Models
{
    public class ExpenseViewModel: ExpenseTypeEntity
    {
        public int TripId { get; set; }
         
        [Required (ErrorMessage ="The field {0} is mandatory.")]
        [Display(Name = "Expense Type")]
        [Range (1, int.MaxValue, ErrorMessage = "You must select a Expense Type.")]
        public int ExpenseTypeID { get; set; }

        [Display(Name = "PicturePath")]
        public IFormFile PicturePath { get; set; }

        public IEnumerable<SelectListItem> Expensetypes { get; set; }

    }
}
