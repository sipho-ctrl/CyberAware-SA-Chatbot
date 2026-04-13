using System;

namespace CyberAwareSA
{
    /// <summary>
    /// Main entry point for the CyberAware SA Cybersecurity Chatbot application.
    /// Creates a chatbot instance and starts the conversation.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method that runs when the application starts.
        /// Sets the console window title and initialises the chatbot.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        static void Main(string[] args)
        {
            // Set the console window title for professional appearance
            Console.Title = "CyberAware SA - Cybersecurity Chatbot";

            // Create and start the chatbot
            Chatbot bot = new Chatbot();
            bot.Start();
        }
    }
}