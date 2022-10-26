using CadastroCliente.CrossCutting.Utils;

namespace CadastroCliente.CrossCutting.Exceptions
{
    public class DomainException : Exception
    {
        private const string ExceptionMessage = "Domain Exception";

        public IEnumerable<string> Errors => Notifications.Select((Notification x) => x.Value);

        public IEnumerable<Notification> Notifications { get; private set; }

        public DomainException(params string[] notifications)
            : base("Domain Exception")
        {
            Notifications = notifications.Select((string x) => new Notification(x));
        }

        public DomainException(Exception innerException, params string[] notifications)
            : base("Domain Exception", innerException)
        {
            Notifications = notifications.Select((string x) => new Notification(x));
        }

        public DomainException(IEnumerable<string> notifications)
            : base("Domain Exception")
        {
            Notifications = notifications.Select((string x) => new Notification(x));
        }

        public DomainException(Exception innerException, IEnumerable<string> notifications)
            : base("Domain Exception", innerException)
        {
            Notifications = notifications.Select((string x) => new Notification(x));
        }

        public DomainException(params Notification[] notifications)
            : base("Domain Exception")
        {
            Notifications = notifications;
        }

        public DomainException(Exception innerException, params Notification[] notifications)
            : base("Domain Exception", innerException)
        {
            Notifications = notifications;
        }

        public DomainException(IEnumerable<Notification> notifications)
            : base("Domain Exception")
        {
            Notifications = notifications;
        }

        public DomainException(Exception innerException, IEnumerable<Notification> notifications)
            : base("Domain Exception", innerException)
        {
            Notifications = notifications;
        }
    }
}
