using ConsoleApp.VisitorPattern.Abstractions;

namespace ConsoleApp.VisitorPattern.Implementations
{
    public class Router : IProduct
    {
        public Guid Code { get; set; }
        public bool PortConnectivity { get; set; }
        public bool Coverage { get; set; }
        public bool InternalTemperature { get; set; }

        public Router(Guid code, bool portConnectivity, bool coverage, bool internalTemperature)
        {
            Code = code;
            PortConnectivity = portConnectivity;
            Coverage = coverage;
            InternalTemperature = internalTemperature;
        }

        public void Accept(IProductVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
