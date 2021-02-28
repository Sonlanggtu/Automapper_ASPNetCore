using FluentValidationASPNET.Domain;
using FluentValidationASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationASPNET.IServices
{
    public interface ICustomerService
    {
        Task<bool> AddCustaomer(CustomerViewModel customerVm);

        Task<IEnumerable<CustomerViewModel>> GetAll();

        Task<CustomerViewModel> GetCustomerById(Guid customerId);
    }
}
