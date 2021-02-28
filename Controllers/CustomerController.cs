using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidationASPNET.Domain;
using FluentValidationASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FluentValidationASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly FluentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(FluentDbContext dbContext,
                                  IMapper mapper,
                                  ILogger<CustomerController> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("GetAllCustomerAsync")]
        public async Task<object> Get()
        {
            // 1. Lazy loading (default entity)
            // Các table liên quan sẽ không được load ra
            //var product_lazyloading = await _dbContext.Products.FirstOrDefaultAsync();
            //var result = product_lazyloading;

            // ==================================================================================================== //
            // 2. Explicit Loading - Load bảng chỉ định sau khi load bảng từ câu lệnh đầu bằng lazyloading

            // * With Loading chieu Conlections - Từ bảng con load ra bảng cha
            // 1 KH có nhiều SP (1 Customer - n Product)
            var customer_Table = await _dbContext.Customers.FirstOrDefaultAsync();
            var products_Conlections = await _dbContext.Entry(customer_Table).Collection(customer => customer.Products)
                                                       .Query()
                                                       .Where(x => x.Price > 100000)
                                                       .ToListAsync();
            var result = products_Conlections.ToList();

            // * Loading chieu Reference - Từ bảng cha load ra bảng con
            //var product_lazyloading = await _dbContext.Products.FirstOrDefaultAsync();
            //await _dbContext.Entry(product_lazyloading).Reference(customer => customer.Customers).LoadAsync();
            //var customer_reference = product_lazyloading.Customers;
            // var result = customer_reference;

            // ==================================================================================================== //
            //3. Eager loading - Load ra các bảng liên quan trong 1 câu lệnh với từ khóa Include
            //var product_EagerLoading = await _dbContext.Products.Include(y => y.Customers).FirstOrDefaultAsync();
            //var result = product_EagerLoading.Customers;

            return Ok(result);
        }

        // GET api/<CustomerController>/5
        [HttpGet("GetAllCustomerAsyncTwo")]
        public object GetAllCustomerAsyncTwo()
        {

            //ParallelLoopResult result = Parallel.For(1, 20, RunTask);   // Vòng lặp tạo ra 20 lần chạy RunTask
            //Console.WriteLine($"All task start and finish: {result.IsCompleted}");


            var persions = new List<Persion>(){
                new Persion()
                {
                   Id = Guid.NewGuid(),
                   Name = "Name 1",
                   Address = "HN",
                   Birthday = DateTime.Now
                },
                new Persion()
                {
                   Id = Guid.NewGuid(),
                   Name = "Name 2",
                   Address = "HN 2",
                   Birthday = DateTime.Now
                }, new Persion()
                {
                   Id = Guid.NewGuid(),
                   Name = "Name 3",
                   Address = "HN 2",
                   Birthday = DateTime.Now
                },
                new Persion()
                {
                   Id = Guid.NewGuid(),
                   Name = "Name 4",
                   Address = "HN",
                   Birthday = DateTime.Now
                },
                new Persion()
                {
                   Id = Guid.NewGuid(),
                   Name = "Name 5",
                   Address = "HN 2",
                   Birthday = DateTime.Now
                }, new Persion()
                {
                   Id = Guid.NewGuid(),
                   Name = "Name 6",
                   Address = "HN 2",
                   Birthday = DateTime.Now
                }

            };


            var stopwatch = new Stopwatch();
            stopwatch.Start();


            Console.WriteLine();
            Parallel.ForEach(persions, RunTaskList);

            return "";
        }

        [NonAction]
        private static async void RunTaskList(Persion persion)
        {

            PintInfo($"Start {persion.Name,3}");
            await Task.Delay(1);          // Task dừng 1s - rồi mới chạy tiếp
            PintInfo($"Finish {persion.Name,3}");


        }

        [NonAction]
        private static async void RunTask(int input)
        {
            PintInfo($"Start {input,3}");
            await Task.Delay(1);          // Task dừng 1s - rồi mới chạy tiếp
            PintInfo($"Finish {input,3}");
        }

        //In thông tin, Task ID và thread ID đang chạy
        [NonAction]
        public static void PintInfo(string info) =>
                Console.WriteLine($"{info,10}    task:{Task.CurrentId,3}    " +
                                  $"thread: {Thread.CurrentThread.ManagedThreadId}");


        // POST api/<CustomerController>
        [HttpPost("CreateCustomerAsync")]
        public async Task<bool> Post()
        {
            var customerVm = new CustomerViewModel();
            customerVm.Id = Guid.NewGuid();
            customerVm.FullName = "DamNgocSon";
            customerVm.UserName = "SonDam";
            customerVm.Password = "123";
            customerVm.Xa = "XuanQuan";
            customerVm.City = "TP.Hung Yen";
            customerVm.Quan = "Van Giang";
            customerVm.PostCode = "1000000";
            customerVm.CMT = "123235467";
            customerVm.Address = "Hung Yen";
            customerVm.Gender = "Nam";
            customerVm.Birdthday = DateTime.Now;

            var customerModel = _mapper.Map<Customer>(customerVm);
            _dbContext.Customers.Add(customerModel);
            var tracker = _dbContext.ChangeTracker.Entries();
            _logger.LogInformation("fist Insert tracker  >> " + tracker);
            await _dbContext.SaveChangesAsync();
            var tracker2 = _dbContext.ChangeTracker.Entries();
            _logger.LogInformation("fist After tracker >> " + tracker2);
            return true;
        }

        [HttpGet("GetAllCustomerAsyncThree")]
        public async ValueTask<object> GetAllCustomerAsyncThree()
        {
            int setvar1 = 10;
            var result = await Task.Run(() => 2 * setvar1);

            return Ok(result);
        }
    }
}
