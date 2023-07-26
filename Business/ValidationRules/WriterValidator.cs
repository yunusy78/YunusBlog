using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class WriterValidator:AbstractValidator<Writer>
{
    public WriterValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Must(ContainUppercase).WithMessage("Password must contain at least one uppercase letter.")
            .Must(ContainLowercase).WithMessage("Password must contain at least one lowercase letter.")
            .Must(ContainDigit).WithMessage("Password must contain at least one digit.");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Name must be at least 2 characters");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
    }
    
    private bool ContainUppercase(string password)
    {
        return password.Any(char.IsUpper);
    }

    private bool ContainLowercase(string password)
    {
        return password.Any(char.IsLower);
    }

    private bool ContainDigit(string password)
    {
        return password.Any(char.IsDigit);
    }
}