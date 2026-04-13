using System;
using System.Threading;

namespace CyberAwareSA
{
    /// <summary>
    /// Handles all console UI enhancements including colours, borders, and typing effects.
    /// </summary>
    public class UIHelper
    {
        /// <summary>
        /// Displays text with a typing animation effect.
        /// </summary>
        /// <param name="text">The text to display</param>
        /// <param name="delayMs">Milliseconds between each character (default 20ms)</param>
        public void TypeText(string text, int delayMs = 20)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Displays a separator line with the specified character and colour.
        /// </summary>
        public void DrawSeparator(char lineChar = '═', ConsoleColor colour = ConsoleColor.DarkCyan)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(new string(lineChar, 70));
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a bordered header with the chatbot name.
        /// </summary>
        public void DrawHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        CYBERAWARE SA CHATBOT                       ║");
            Console.WriteLine("║                  Your Cybersecurity Awareness Assistant           ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays a success message in green.
        /// </summary>
        public void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[✓] {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays an info message in blue.
        /// </summary>
        public void InfoMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[i] {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a warning message in yellow.
        /// </summary>
        public void WarningMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[!] {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a bot response with typing effect.
        /// </summary>
        public void BotResponse(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("🤖 Chatbot: ");
            Console.ResetColor();
            TypeText(message, 15);
        }
    }
}