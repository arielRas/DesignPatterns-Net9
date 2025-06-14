namespace ConsoleApp.DecoratorPattern.Entities
{
    public class Notification
    {
        public Notified Customer { get; set; }
        public string Message { get; set; }

        public Notification(Notified customer, string message)
        {
            Customer = customer;
            Message = message;
        }
    }
}
