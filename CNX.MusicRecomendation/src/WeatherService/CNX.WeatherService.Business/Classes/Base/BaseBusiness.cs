using CNX.WeatherService.Business.Util;
using CNX.WeatherService.Model.Entities.Base;
using FluentValidation;
using FluentValidation.Results;

namespace CNX.WeatherService.Business.Classes.Base
{
    public abstract class BaseBusiness
    {
        private readonly INotifier _notifier;

        public BaseBusiness(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected void Notify(string message, string innerExceptionMsg)
        {
            _notifier.Handle(new Notification(message, innerExceptionMsg));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entidade) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            var validate = validation.Validate(entidade);

            if (validate.IsValid) return true;

            Notify(validate);

            return false;
        }

    }
}
