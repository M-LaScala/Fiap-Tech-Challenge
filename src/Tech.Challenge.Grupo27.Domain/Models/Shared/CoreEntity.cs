using FluentValidation;
using FluentValidation.Results;

namespace Tech.Challenge.Grupo27.Domain.Models.Shared
{
    public class CoreEntity
    {
        public Guid Id { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public DateTime? DataDeAlteracao { get; set; }

        public bool Valid { get; private set; }
        public bool Invalid => !Valid;
        public ValidationResult? ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
