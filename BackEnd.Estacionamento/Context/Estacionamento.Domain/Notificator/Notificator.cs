using Estacionamento.Domain.Contracts.Notificator;
using FluentValidation.Results;

namespace Estacionamento.Domain.Notificator
{
    public class Notificator : INotificator
    {
        private readonly ValidationResult _notifications;

        public Notificator() => 
            _notifications = new ValidationResult();

        public void Handle(ValidationFailure notification) =>
            _notifications.Errors.Add(notification);

        public List<ValidationFailure> GetNotifications() =>
            _notifications.Errors;

        public bool HasNotifications() =>
            _notifications.Errors.Any();
    }
}
