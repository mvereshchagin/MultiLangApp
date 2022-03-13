using MultiLangApp.Classes;
using MultiLangApp.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;

namespace MultiLangAppTests
{
    [TestFixture]
    internal class ProjectTests
    {
        [TestCase("Vasya")]
        [TestCase("Petya")]
        public void Run_UserSelect1AndName_ChangeLanguageToRussian(string name)
        {
            // Arrange
            var messages = new object[]
            {
                "Welcome\r\n",
                "Please, choose language\r\n",
                "[1] for Russian\r\n",
                "[2] for English\r\n",
                "1\r\n",
                "Введите ваше имя\r\n",
                name + "\r\n",
                $"Привет, {name}\r\n",
                "Спасибо\r\n",
                "Нажмите любую клавишу для завершения\r\n",
                new ConsoleKeyInfo()
            };
            int messageNumber = 0;


            IConsole innerConsole = Substitute.For<IConsole>();
            innerConsole.ReadLine().Returns("1", name);
            
            ConsoleWithNotification console = new ConsoleWithNotification(innerConsole);

            IOutputManager outputManager = Substitute.For<IOutputManager>();
            outputManager.GetString("Greeting").Returns("Welcome");
            outputManager.GetString("ChooseLanguage").Returns("Please, choose language");
            outputManager.GetString("ForRussian").Returns("[1] for Russian");
            outputManager.GetString("ForEnglish").Returns("[2] for English");
            outputManager.GetString("EnterYourName").Returns("Введите ваше имя");
            outputManager.GetString("HelloName").Returns($"Привет, {name}");
            outputManager.GetString("ThankYou").Returns("Спасибо");
            outputManager.GetString("AnyKeyToExit").Returns("Нажмите любую клавишу для завершения");

            var project = new Project(outputManager, console);

            console.OnConsoleChanged += new EventHandler<object>((sender, text) =>
            {
                // Assert
                Assert.AreEqual(messages[messageNumber], text); 
                messageNumber++;
            });

            // Act
            project.Run();
        }

        [TestCase("Vasya")]
        [TestCase("Petya")]
        public void Run_UserSelect2AndName_ReturnsNothing(string name)
        {
            // Arrange
            var messages = new object[]
            {
                "Welcome\r\n",
                "Please, choose language\r\n",
                "[1] for Russian\r\n",
                "[2] for English\r\n",
                "2\r\n",
                "Enter your name\r\n",
                name + "\r\n",
                $"Hello, {name}\r\n",
                "Thank you\r\n",
                "Press any key to exit\r\n",
                new ConsoleKeyInfo()
            };
            int messageNumber = 0;


            IConsole innerConsole = Substitute.For<IConsole>();
            innerConsole.ReadLine().Returns("2", name);

            ConsoleWithNotification console = new ConsoleWithNotification(innerConsole);

            IOutputManager outputManager = Substitute.For<IOutputManager>();
            outputManager.GetString("Greeting").Returns("Welcome");
            outputManager.GetString("ChooseLanguage").Returns("Please, choose language");
            outputManager.GetString("ForRussian").Returns("[1] for Russian");
            outputManager.GetString("ForEnglish").Returns("[2] for English");
            outputManager.GetString("EnterYourName").Returns("Enter your name");
            outputManager.GetString("HelloName").Returns($"Hello, {name}");
            outputManager.GetString("ThankYou").Returns("Thank you");
            outputManager.GetString("AnyKeyToExit").Returns("Press any key to exit");

            var project = new Project(outputManager, console);

            console.OnConsoleChanged += new EventHandler<object>((sender, text) =>
            {
                // Assert
                Assert.AreEqual(messages[messageNumber], text);
                messageNumber++;
            });

            // Act
            project.Run();
        }
    }
}
