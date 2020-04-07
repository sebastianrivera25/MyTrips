using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrips.Web.Data.Entities
{
    public class CityEntity
    {
        public int Id { get; set; }

        [Display(Name = "City")]
        [MaxLength(100, ErrorMessage = "The field {0} can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        public ICollection<TripEntity> Trips { get; set; }
    }
}
