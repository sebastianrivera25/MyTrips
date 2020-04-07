using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrips.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext contex)
        {
            _context = contex;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckExpenseTypeAsync();
            await CheckExpenseAsync();
            await CheckCityAsync();
            await CheckTripAsync();
        }

        private async Task CheckExpenseTypeAsync()
        {
            if (_context.ExpenseTypes.Any())
            {
                _context.ExpenseTypes.Add(new Entities.ExpenseTypeEntity { Name = "Transport" });
                _context.ExpenseTypes.Add(new Entities.ExpenseTypeEntity { Name = "Food" });
                _context.ExpenseTypes.Add(new Entities.ExpenseTypeEntity { Name = "lodgement" });
                await _context.SaveChangesAsync();
            }
        }

        private Task CheckTripAsync()
        {
            throw new NotImplementedException();
        }

        private Task CheckCityAsync()
        {
            throw new NotImplementedException();
        }

        private Task CheckExpenseAsync()
        {
            throw new NotImplementedException();
        }


    }
}
