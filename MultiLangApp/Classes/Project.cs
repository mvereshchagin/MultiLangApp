using MultiLangApp.Interfaces;

namespace MultiLangApp.Classes
{
    public class Project : IProject
    {
        private readonly IConsole _console;
        private readonly IOutputManager _outputManager;

        public Project(IOutputManager outputManager, IConsole console)
        {
            _outputManager = outputManager;
            _console = console;
        }
    
        public void Run()
        {
            this.WriteLine("Greeting");
            this.WriteLine("ChooseLanguage");
            this.WriteLine("ForRussian");
            this.WriteLine("ForEnglish");

            bool res = false;
            do
            {
                var strChoice = _console.ReadLine();
                res = Int32.TryParse(strChoice, out var choice);
                if(res)
                {
                    switch(choice)
                    {
                        case 1:
                            _outputManager.Lang = "ru";
                            break;
                        case 2:
                            _outputManager.Lang = "en";
                            break;
                        default:
                            _outputManager.Lang = "en";
                            break;
                    }
                    break;
                }
                else
                {
                    _console.Clear();
                }
            }
            while (!res);
            
            this.WriteLine("EnterYourName");
            var name = _console.ReadLine();
            this.WriteLine("HelloName", name);
            this.WriteLine("ThankYou");
            this.WriteLine("AnyKeyToExit");
            var key = _console.ReadKey();
        }

        private void WriteLine(string key, params object?[] args)
        {
            var text = _outputManager.GetString(key);
            if(text is not null)
                _console.WriteLine(text, args);
        }
    }
}
