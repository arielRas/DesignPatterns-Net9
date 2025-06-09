using ConsoleApp.VisitorPattern.Abstractions;

namespace ConsoleApp.VisitorPattern.Implementations
{
    public class SmartPhone : IProduct
    {
        public Guid Code { get; set; }
        public bool Signal { get; set; }
        public bool Screen { get; set; }
        public bool Battery { get; set; }
        public bool Camera { get; set; }

        public SmartPhone(Guid code, bool signal, bool screen, bool battery, bool camera)
        {
            Code = code;
            Signal = signal;
            Screen = screen;
            Battery = battery;
            Camera = camera;
        }

        public void Accept(IProductVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
