namespace MathModeling.WpfApplication.Lab1
{
    public interface IRandomGenerator
    {
        string Name { get; }

        double GenerateNext();
    }
}