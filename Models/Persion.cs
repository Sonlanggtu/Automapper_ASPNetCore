using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationASPNET.Models
{
    public class Persion
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        public string Address { get; set; }
    }
}
