using Business.DTOs.ProductDtos;
using FluentValidation;
using FluentValidation.Validators;

namespace Business.Validators.ProductValidators;

public class ProductPostDtoValidator: AbstractValidator<ProductPostDto>
{
    public ProductPostDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotNull().WithMessage("Null ola bilmez!")
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
        RuleFor(p => p.Description)
              .NotEmpty()
              .MinimumLength(5)
              .MaximumLength(500);
        RuleFor(p => p.Price)
            .NotNull()
            .GreaterThan(0);
        RuleFor(p=>p.Rating)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(5);
         
     }
}
