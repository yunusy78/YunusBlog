using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class CategoryValidator : AbstractValidator<Category>

{
    
public CategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Category name cannot be empty");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Category name must be at least 2 characters");
        RuleFor(x => x.Name).MaximumLength(20).WithMessage("Category name must be at most 20 characters");
        RuleFor(x=>x.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(x => x.Description).MinimumLength(3).WithMessage("Description must be at least 3 characters");
        RuleFor(x => x.Description).MaximumLength(100).WithMessage("Description must be at most 100 characters");

    }
    
    
}