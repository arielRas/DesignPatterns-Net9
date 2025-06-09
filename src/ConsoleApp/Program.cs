using ConsoleApp.MementoPattern.Implementations;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestMemento();
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
    }
}
