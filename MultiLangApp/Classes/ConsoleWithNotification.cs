using MultiLangApp.Interfaces;

namespace MultiLangApp.Classes;

public class ConsoleWithNotification : IConsole
{
    private readonly IConsole _console;

    public void WriteLine(string text, params object?[] args)
    {
        var res = String.Format(text + "\r\n", args);
        _console.WriteLine(text, args);
        OnConsoleChanged?.Invoke(this, res);
    }

    public void Write(string text, params object?[] args)
    {
        var res = String.Format(text, args);
        _console.WriteLine(text, args);
        OnConsoleChanged?.Invoke(this, res);
    }

    public string? ReadLine()
    {
        var res = _console.ReadLine();
        OnConsoleChanged?.Invoke(this, res + "\r\n");
        return res;
    }

    public ConsoleKeyInfo ReadKey()
    {
        var res = _console.ReadKey();
        OnConsoleChanged?.Invoke(this, res);
        return res;
    }

    public void Clear()
    {
        OnConsoleChanged?.Invoke(this, String.Empty);
    }

    public event EventHandler<object>? OnConsoleChanged;
    
    public ConsoleWithNotification(IConsole console)
    {
        _console = console;
    }
}