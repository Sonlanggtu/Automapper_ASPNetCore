using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationASPNET.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FullName { set; get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Xa { get; set; }
        public string City { get; set; }
        public string Quan { get; set; }
        public string PostCode { get; set; }
        public string CMT { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public string Gender { get; set; }
        public DateTime? Birdthday { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
