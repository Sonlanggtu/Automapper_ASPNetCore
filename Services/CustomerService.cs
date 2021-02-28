using FluentValidationASPNET.Domain;
using FluentValidationASPNET.IServices;
using FluentValidationASPNET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationASPNET.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly FluentDbContext _dbcontext;

        public CustomerService(FluentDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> AddCustaomer(CustomerViewModel customerVm)
        {
            return false;
            // _dbcontext.Customers.
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            var listCustomers = await _dbcontext.Customers.ToListAsync();

            //return listCustomers;
            List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();

            return customerViewModels;
        }

        public Task<CustomerViewModel> GetCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
