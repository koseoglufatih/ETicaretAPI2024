﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZTicaret.Application.Features.Commands.Product.Create
{

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .WithMessage("Lütfen 'Name'i boş geçmeyiniz.")
                .MaximumLength(20)
                .MinimumLength(3)
                .WithMessage("'Name' değeri 3 ile 20 karakter arasında olmalıdır.");
            RuleFor(p => p.Price)
                .Must(p => p > 0)
                .WithMessage("Lütfen 'Price' değerini doğru giriniz.");
            RuleFor(p => p.Stock)
               .Must(p => p > 0)
               .WithMessage("Lütfen 'Stock' değerini doğru giriniz.");
        }
    }
}
