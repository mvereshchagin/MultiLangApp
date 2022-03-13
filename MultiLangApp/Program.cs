using MultiLangApp.Classes;
using MultiLangApp.Interfaces;

IOutputManager outputManager = new ResourceOutputManager();
IConsole console = new StrictConsole();
IProject project = new Project(outputManager, console);
project.Run();

