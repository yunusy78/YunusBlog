using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class BlogValidator:AbstractValidator<Blog>
{
    public BlogValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty");
        RuleFor(x => x.Content).NotEmpty().WithMessage("Content cannot be empty");
        RuleFor(x => x.Title).MinimumLength(2).WithMessage("Title must be at least 2 characters");
        RuleFor(x => x.Content).MinimumLength(2).WithMessage("Content must be at least 2 characters");
        
    }
    
}