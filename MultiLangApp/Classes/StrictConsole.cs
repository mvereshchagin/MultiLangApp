using MultiLangApp.Interfaces;

namespace MultiLangApp.Classes
{
    internal class StrictConsole : IConsole
    {
        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public void Clear()
        {
            Console.Clear();
        }
        

        public string? ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string text, params object?[] args)
        {
            Console.Write(text, args);
        }

        public void WriteLine(string text, params object?[] args)
        {
            Console.WriteLine(text, args);
        }
    }
}
