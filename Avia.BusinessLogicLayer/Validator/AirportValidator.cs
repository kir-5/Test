using Avia.BusinessLogicLayer.Models;
using FluentValidation;

namespace Avia.BusinessLogicLayer.Validator
{
    public class AirportValidator : AbstractValidator<Airport>
    {
        public AirportValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .Length(3)
                .Must(x => x.All(char.IsLetter))
                .WithMessage("Введите Код аэропорта. Код должен состоять из трёх букв");
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Введите Название");
            RuleFor(x => x.CityId)
                .NotEmpty()
                .WithMessage("Введите Идентификатор города");
        }
    }
}
