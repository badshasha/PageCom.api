using FluentValidation;

namespace PageCom.Api.Application.DTO.BookDTO.validator;

public class BookViewDTOValidator : AbstractValidator<BookViewDTO>
{
    public BookViewDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("name required")
            .NotNull().WithMessage("null value not allowed")
            .Length(2, 20).WithMessage("2 to 20 characters allow");
        //.Must(NotContainingSpecialCharacter).WithMessage("special characters not allow");
    }

    private bool NotContainingSpecialCharacter(string name)
    {
        var value = name.Any(character => !char.IsLetterOrDigit(character));
        return !value;
    }
}