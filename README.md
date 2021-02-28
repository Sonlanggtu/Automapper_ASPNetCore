# Automapper_ASPNetCore
This Intergration Automapper in ASPNET CORE

![Image of Automapper](https://github.com/Sonlanggtu/Automapper_ASPNetCore/blob/main/Images/AutoMapper.PNG)

B1: Install 3th Nuget Automapper 10.1.1
B2: Write Configuration Class Mapping 
   Create File CustomerMappingProfile.cs

    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>().ReverseMap();
            //CreateMap<List<CustomerViewModel>, List<Customer>>();
        }
    }

B3. Config Startup.cs

            // AutoMapper
            #region Add AutoMapper
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new CustomerMappingProfile());
            });
            services.AddSingleton(provider => mapperConfig.CreateMapper());
            #engion Add AutoMapper
B4: Use Automapping
   
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

