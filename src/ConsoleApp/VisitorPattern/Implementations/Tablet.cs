using ConsoleApp.VisitorPattern.Abstractions;

namespace ConsoleApp.VisitorPattern.Implementations
{
    public class Tablet : IProduct
    {
        public Guid Code { get; set; }
        public bool Screen { get; set; }
        public bool Battery { get; set; }
        public bool Sensors { get; set; }

        public Tablet(Guid code, bool signal, bool screen, bool battery, bool sensors)
        {
            Code = code;
            Screen = screen;
            Battery = battery;
            Sensors = sensors;
        }
        public void Accept(IProductVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
