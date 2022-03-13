namespace MultiLangApp.Interfaces
{
    public interface IConsole
    {
        void WriteLine(string text, params object?[] args);
        void Write(string text, params object?[] args);
        string? ReadLine();
        
        ConsoleKeyInfo ReadKey();

        void Clear();
    }
}
