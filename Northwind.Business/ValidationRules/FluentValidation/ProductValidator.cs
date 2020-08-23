using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismini girmelisiniz.");
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            //RuleFor(p => p.UnitsInStock).NotEmpty().WithMessage("Stok 0 olmaz");
            RuleFor(p => p.UnitPrice).GreaterThan((short)0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır.");

            //RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0).WithMessage("Stok 0'dan küçük olamaz");
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 1).WithMessage("Seçilen kategorideki ürünlerin fiyatı 10 ve altında olamaz!");

            //RuleFor(p => p.ProductName).Must(StartWithB).WithMessage("Ürün B Harfi ile başlamalıdır.");

        }

        private bool StartWithB(string arg) 
        {
            return arg.StartsWith("B");
        }

        
    }

}
