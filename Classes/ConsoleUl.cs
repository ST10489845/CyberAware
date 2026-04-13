using System;
using System.Threading;

namespace CyberAware.Classes
{
    public class ConsoleUI
    {
        public void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string art = @"
    ╔════════════════════════════════════════════════════════════════════════════════════════╗
    ║                                                                                        ║
    ║         ██████╗██╗   ██╗██████╗ ███████╗██████╗  █████╗ ██╗    ██╗ █████╗ ██████╗ ███████╗║
    ║        ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔══██╗██║    ██║██╔══██╗██╔══██╗██╔════╝║
    ║        ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝███████║██║ █╗ ██║███████║██████╔╝█████╗  ║
    ║        ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗██╔══██║██║███╗██║██╔══██║██╔══██╗██╔══╝  ║
    ║        ╚██████╗   ██║   ██║  ██║███████╗██║  ██║██║  ██║╚███╔███╔╝██║  ██║██║  ██║███████╗║
    ║         ╚═════╝   ╚═╝   ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝ ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝║
    ║                                                                                        ║
    ║                              CYBERAWARE - STAY SAFE ONLINE                          ║
    ║                                          BOT                                        ║
    ║                                                                                        ║
    ╚════════════════════════════════════════════════════════════════════════════════════════╝";

            Console.WriteLine(art);
            Console.ResetColor();
            Thread.Sleep(1500);
        }

        public void DisplayWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + new string('═', 78));
            Console.WriteLine("║" + new string(' ', 76) + "║");
            Console.WriteLine("║      WELCOME TO CYBERAWARE - YOUR SECURITY ASSISTANT    ║");
            Console.WriteLine("║" + new string(' ', 76) + "║");
            Console.WriteLine(new string('═', 78));
            Console.ResetColor();
            Thread.Sleep(800);
        }

        public void DisplayPersonalisedGreeting(string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n HELLO, {name.ToUpper()}! ");
            Console.WriteLine(" I'm CyberAware - your personal guide to staying safe online!");
            Console.WriteLine(" I'm part of the national campaign against cyber threats.");
            Console.ResetColor();
            Thread.Sleep(500);
        }

        public void DisplayHelpMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n" + new string('─', 78));
            Console.WriteLine(" TOPICS YOU CAN ASK CYBERAWARE ABOUT:");
            Console.WriteLine($"    Password safety & best practices");
            Console.WriteLine($"    Phishing scams & email fraud");
            Console.WriteLine($"    Safe browsing habits");
            Console.WriteLine($"\n SAMPLE QUESTIONS:");
            Console.WriteLine($"   • \"How are you?\"");
            Console.WriteLine($"   • \"What's your purpose?\"");
            Console.WriteLine($"   • \"What can I ask you about?\"");
            Console.WriteLine($"\n Type 'exit' or 'bye' to end the conversation");
            Console.WriteLine(new string('─', 78));
            Console.ResetColor();
        }

        public void DisplayBotResponse(string response)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n CYBERAWARE: ");
            Console.ResetColor();
            TypeWithDelay(response, 35);
            Console.WriteLine();
        }

        public void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n ERROR: {message}");
            Console.ResetColor();
        }

        public void DisplayPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n YOU: ");
            Console.ResetColor();
        }

        public void DisplayFarewell(string name)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + new string('═', 78));
            TypeWithDelay($"\n GOODBYE, {name.ToUpper()}! ", 40);
            TypeWithDelay("\n REMEMBER: Stay vigilant, think before you click, and keep your data safe!", 40);
            TypeWithDelay("\n Thank you for using CyberAware!\n", 40);
            Console.WriteLine(new string('═', 78));
            Console.ResetColor();
        }

        public void TypeWithDelay(string text, int delayMs)
        {
            bool originalVisibility = Console.CursorVisible;
            Console.CursorVisible = false;

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }

            Console.CursorVisible = originalVisibility;
        }
    }
}