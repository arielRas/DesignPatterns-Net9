using ConsoleApp.AbstractFactorypattern.Entities;
using ConsoleApp.AbstractFactoryPattern.Abstractions;
using ConsoleApp.AbstractFactoryPattern.Enums;
using ConsoleApp.AbstractFactoryPattern.Factory;
using ConsoleApp.CompositePattern.Implementations;
using ConsoleApp.FactoryPattern.Abstractions;
using ConsoleApp.FactoryPattern.Enums;
using ConsoleApp.FactoryPattern.Implementations;
using ConsoleApp.MementoPattern.Implementations;
using ConsoleApp.RepositoryPattern.Entities;
using ConsoleApp.RepositoryPattern.Factory.Abstractions;
using ConsoleApp.RepositoryPattern.Factory.Implementations;
using ConsoleApp.RepositoryPattern.Repository.Abstractions;
using ConsoleApp.RepositoryPattern.Settings;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestMemento();
            //TestComposite();
            //TestFactory();
            //TestAbstractFactory();
            TestRepository();
        }

        static void TestMemento()
        {
            //----------------Creacion de imagen---------------------\\

            var image = new Image(10, 8.5m, 12, 50);
            Console.WriteLine("\tImagen inicial");
            image.PrintCurrentProperties();


            //--------Modificacion de la propiedad ColorFilter--------\\

            Console.WriteLine("\tModificacion de propiedades");
            image.SetColorFilter(1.00m);
            image.PrintCurrentProperties();

            Console.WriteLine("\tSe desahacen cambios");
            image.Undo();
            image.PrintCurrentProperties();

            Console.WriteLine("\tSe rehacen cambios cambios");
            image.Redo();
            image.PrintCurrentProperties();


            //---------Modificacion de la propiedad Rotation---------\\

            Console.WriteLine("\tModificacion de propiedades");
            image.SetRotation(1.00m);
            image.PrintCurrentProperties();

            Console.WriteLine("\tSe desahacen cambios");
            image.Undo();
            image.PrintCurrentProperties();

            Console.WriteLine("\tSe desahacen cambios");
            image.Redo();
            image.PrintCurrentProperties();


            //----------Modificacion de la propiedad Crop----------\\

            Console.WriteLine("\tModificacion de propiedades");
            image.SetCrop(1.00m);
            image.PrintCurrentProperties();

            Console.WriteLine("\tSe desahacen cambios");
            image.Undo();
            image.PrintCurrentProperties();

            Console.WriteLine("\tSe desahacen cambios");
            image.Redo();
            image.PrintCurrentProperties();


            //------Modificacion de la propiedad Compression------\\

            Console.WriteLine("\tModificacion de propiedades");
            image.SetCompression(1.00m);
            image.PrintCurrentProperties();

            Console.WriteLine("\tSe desahacen cambios");
            image.Undo();
            image.PrintCurrentProperties();

            Console.WriteLine("\tSe desahacen cambios");
            image.Redo();
            image.PrintCurrentProperties();
        }
    
        static void TestComposite()
        {            
            
            Console.WriteLine("Ingrese la ruta que desea analizar: \n");

            string path = Console.ReadLine();

            var rootDirectory = new DirectoryItem();

            rootDirectory.LoadFromPath(path);

            rootDirectory.Display();

            Console.ReadKey();
        }
    
        static void TestFactory()
        {
            //Creacion de clases
            Console.WriteLine("\t~~~~~~Creacion de Cuentas~~~~~~\n");
            IFactoryAccount factory = new FactoryAccount();

            IAccount bankAccount = factory.Create(AccountTypes.Bank);
            IAccount virtualWallet = factory.Create(AccountTypes.VirtualWallet);

            //Primer deposito
            bankAccount.Deposit(100.00);
            virtualWallet.Deposit(150.00);

            //Transferencia entre cuentas
            bankAccount.Transfer(virtualWallet, 50.00);

            //Resultados
            Console.WriteLine("\n\t~~~~~~Resultados~~~~~~\n");
            Console.WriteLine($"El saldo de la cuenta de banco es: {bankAccount.Balance}$");
            Console.WriteLine($"El saldo de la villetera virtual es: {virtualWallet.Balance}$");
            Console.ReadKey();
        }    
    
        static void TestAbstractFactory()
        {
            IFactoryArgentina argentinaFactory = new FactoryArgentina();
            IFactoryUsa usaFactory = new FactoryUsa();
            IFactorySpain spainFactory = new FactorySpain();

            var address = new Address
            {
                Street = "Calle de prueba",
                Number = 123,
                Country = Countries.Argentina
            };

            //Elementos de Argentina
            IInvoice invoice = argentinaFactory.CreateInvoice(1000);
            IShipment shipment = argentinaFactory.CreateShipment(address);
            invoice.Identify();
            shipment.Identify();

            //Elementos de USA
            invoice = usaFactory.CreateInvoice(500);
            shipment = usaFactory.CreateShipment(address);
            invoice.Identify();
            shipment.Identify();

            //Elementos de España
            invoice = spainFactory.CreateInvoice(500);
            shipment = spainFactory.CreateShipment(address);
            invoice.Identify();
            shipment.Identify();
        }
        
        static void TestRepository()
        {
            IFactoryCustomerRepository factoryCustomerRepository = new FactoryCustomerRepository();
            IFactoryProductRepository factoryProductRepository = new FactoryProductRepository();

            ICustomerRepository customerRepository = factoryCustomerRepository.CreateRepository();
            IProductRepository productRepository = factoryProductRepository.CreateRepository();

            if (DbEngineSettings.Engine.ToLower().Trim() == "mongo")
                InsertMongoData(customerRepository, productRepository);

            customerRepository.GetAll().ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Id} - {x.Name} - {x.Email}");
            });

            productRepository.GetAll().ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Id} - {x.Name} - {x.Price}");
            });
        }

        static void InsertMongoData(ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            var customers = new List<Customer>
                {
                    new Customer
                    {
                        Id = Guid.Parse("b094c314-4f25-41f2-b30e-b3001192d86d"),
                        Name = "TestCustomer01",
                        Email = "TestCustomer01@test.com"
                    },
                    new Customer
                    {
                        Id = Guid.Parse("d1d09b30-6a91-4c7f-a60e-ea70a2b15642"),
                        Name = "TestCustomer02",
                        Email = "TestCustomer02@test.com"
                    },
                    new Customer
                    {
                        Id = Guid.Parse("a04cb876-3be7-4912-8055-2972ae3fb5f2"),
                        Name = "TestCustomer03",
                        Email = "TestCustomer03@test.com"
                    },
                };

            var products = new List<Product>
                {
                    new Product
                    {
                        Id = Guid.Parse("bd3c99ee-b312-4531-9a82-c79f903fdee0"),
                        Name = "TestProduct01",
                        Price = 200m
                    },
                    new Product
                    {
                        Id = Guid.Parse("be23af6a-39ec-4abe-aa83-5758a5ee0795"),
                        Name = "TestProduct02",
                        Price = 500
                    },
                    new Product
                    {
                        Id = Guid.Parse("50b83f41-cf19-4032-8892-8444de8b5eb2"),
                        Name = "TestProduct03",
                        Price = 1000
                    },
                };

            customers.ForEach(x =>
            {
                if (!customerRepository.Exists(x.Id))
                    customerRepository.Create(x);
            });

            products.ForEach(x =>
            {
                if (!productRepository.Exists(x.Id)) 
                    productRepository.Create(x);
            });
        }
    }
}
