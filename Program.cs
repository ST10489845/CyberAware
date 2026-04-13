using System;
using CyberAware.Classes;

namespace CyberAware
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CyberAware - Security Assistant";
            Console.SetWindowSize(100, 40);

            using (var chatbot = new Chatbot())
            {
                chatbot.Start();
            }
        }
    }
}