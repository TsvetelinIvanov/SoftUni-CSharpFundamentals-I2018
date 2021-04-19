namespace _01Logger
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string message);
    }
}