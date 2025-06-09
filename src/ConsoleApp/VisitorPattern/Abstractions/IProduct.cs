namespace ConsoleApp.VisitorPattern.Abstractions
{
    public interface IProduct
    {
        Guid Code { get; set; }
        void Accept(IProductVisitor visitor);
    }
}
