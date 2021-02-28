using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationASPNET.Models.ValidationModel
{
    public class CustomerValidation : AbstractValidator<CustomerViewModel>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Yêu cầu nhập tài khoản");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Yêu cầu nhập mật khẩu");
        }

    }
}
