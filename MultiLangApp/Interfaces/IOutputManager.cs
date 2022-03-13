namespace MultiLangApp.Interfaces
{
    public interface IOutputManager
    {

        string Lang { get; set; }
        string? GetString(string name);
    }
}
