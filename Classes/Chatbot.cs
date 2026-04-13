using System;
using System.Threading;

namespace CyberAware.Classes
{
    public class Chatbot : IDisposable
    {
        private AudioService audioService;
        private ConsoleUI ui;
        private ResponseHandler responseHandler;
        private string userName;
        private bool isRunning;

        public Chatbot()
        {
            audioService = new AudioService();
            ui = new ConsoleUI();
            responseHandler = new ResponseHandler();
            isRunning = true;
        }

        public void Start()
        {
            try
            {
                audioService.PlayGreeting();
                ui.DisplayAsciiArt();
                ui.DisplayWelcomeMessage();
                userName = GetValidatedName();
                ui.DisplayPersonalisedGreeting(userName);
                ui.DisplayHelpMenu();
                RunConversationLoop();
                ui.DisplayFarewell(userName);
            }
            catch (Exception ex)
            {
                ui.DisplayError($"Critical error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        private string GetValidatedName()
        {
            while (true)
            {
                ui.TypeWithDelay("\n Please tell me your name: ", 40);
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    ui.DisplayError("Input cannot be empty. Please enter your name.");
                }
                else if (input.Length < 2)
                {
                    ui.DisplayError("Name must be at least 2 characters long.");
                }
                else if (input.Length > 30)
                {
                    ui.DisplayError("Name is too long. Please use 30 characters or less.");
                }
                else if (ContainsNumbers(input))
                {
                    ui.DisplayError("Name should not contain numbers. Please use letters only.");
                }
                else
                {
                    return char.ToUpper(input[0]) + input.Substring(1).ToLower();
                }
            }
        }

        private bool ContainsNumbers(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                    return true;
            }
            return false;
        }

        private void RunConversationLoop()
        {
            ui.TypeWithDelay($"\n How can I help you with cybersecurity today, {userName}?", 40);

            while (isRunning)
            {
                ui.DisplayPrompt();
                string userInput = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    ui.DisplayError("I didn't catch that. Please say something or type 'exit' to quit.");
                    continue;
                }

                string lowerInput = userInput.ToLower();

                if (lowerInput == "exit" || lowerInput == "quit" || lowerInput == "bye" || lowerInput == "goodbye")
                {
                    isRunning = false;
                    continue;
                }

                string response = responseHandler.GetResponse(lowerInput, userName);
                ui.DisplayBotResponse(response);
                Thread.Sleep(600);
            }
        }

        public void Dispose()
        {
            if (audioService is IDisposable disposable)
                disposable.Dispose();
        }
    }
}