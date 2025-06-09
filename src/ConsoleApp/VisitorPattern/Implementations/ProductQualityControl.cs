using ConsoleApp.VisitorPattern.Abstractions;

namespace ConsoleApp.VisitorPattern.Implementations
{
    public class ProductQualityControl : IProductVisitor
    {
        public void Visit(SmartPhone product)
        {
            if (product.Screen && product.Signal && product.Battery && product.Camera)
            {
                Console.WriteLine($"El smarthphone con codigo: {product.Code} paso la prueba de calidad");
            }
            else
            {
                Console.WriteLine($"El smarthphone con codigo: {product.Code} ha fallado la prueba calidad");
            }
        }

        public void Visit(Tablet product)
        {
            if (product.Screen && product.Battery && product.Sensors)
            {
                Console.WriteLine($"La tablet con codigo: {product.Code} paso la prueba de calidad");
            }
            else
            {
                Console.WriteLine($"La tablet con codigo: {product.Code} ha fallado la prueba calidad");
            }
        }

        public void Visit(Router product)
        {
            if (product.PortConnectivity && product.Coverage && product.InternalTemperature)
            {
                Console.WriteLine($"El router con codigo: {product.Code} paso la prueba de calidad");
            }
            else
            {
                Console.WriteLine($"El router con codigo: {product.Code} ha fallado la prueba calidad");
            }
        }
    }
}
