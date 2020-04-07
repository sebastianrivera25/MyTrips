using MyTrips.Web.Data.Entities;
using MyTrips.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrips.Web.Helpers
{
    public interface IConverterHelper
    {
         ExpenseEntity ToExpenseEntity(ExpenseViewModel model, string path, bool isNew);

         ExpenseViewModel ToExpenseViewModel(ExpenseEntity ExpenseEntity);
    }
}
