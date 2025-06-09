using ConsoleApp.CompositePattern.Implementations;
using ConsoleApp.FactoryPattern.Abstractions;
using ConsoleApp.FactoryPattern.Enums;
using ConsoleApp.FactoryPattern.Implementations;
using ConsoleApp.MementoPattern.Implementations;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestMemento();
            //TestComposite();
            //TestFactory();
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
    
    }
}
