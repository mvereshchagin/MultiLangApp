using MultiLangApp.Interfaces;
using System.Globalization;
using System.Reflection;
using System.Resources;


namespace MultiLangApp.Classes
{
    internal class ResourceOutputManager : IOutputManager
    {
        private ResourceManager _rm;
        private string _lang;
        private CultureInfo _cultureInfo;

        public string Lang 
        { 
            get => _lang;
            set
            {
                _lang = value;
                _cultureInfo = new CultureInfo(_lang);
            }
        }

        public ResourceOutputManager()
        {
            _lang = "en";
            _cultureInfo = new CultureInfo(_lang);
            _rm = new ResourceManager("MultiLangApp.Resources.Strings", Assembly.GetExecutingAssembly());
        }

        public string? GetString(string name)
        {
            return _rm.GetString(name, this._cultureInfo);
        }
    }
}
