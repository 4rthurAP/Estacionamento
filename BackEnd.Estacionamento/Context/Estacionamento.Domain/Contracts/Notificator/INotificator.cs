using FluentValidation.Results;

namespace Estacionamento.Domain.Contracts.Notificator
{
    public interface INotificator
    {
        bool HasNotifications();
        List<ValidationFailure> GetNotifications();
        void Handle(ValidationFailure notification);
    }
}
