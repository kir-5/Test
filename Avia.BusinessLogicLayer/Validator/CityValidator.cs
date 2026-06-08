using Avia.BusinessLogicLayer.Models;
using FluentValidation;

namespace Avia.BusinessLogicLayer.Validator
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .Length(3)
                .Must(x => x.All(char.IsLetter))
                .WithMessage("Введите Код города. Код должен состоять из трёх букв");
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Введите Название");
        }
    }
}
