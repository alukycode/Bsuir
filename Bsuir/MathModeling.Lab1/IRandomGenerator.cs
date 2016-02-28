namespace MathModeling.Lab1
{
    public interface IRandomGenerator
    {
        string Name { get; }

        double GenerateNext();
    }
}