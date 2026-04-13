using System;

namespace CyberAwareSA
{
    /// <summary>
    /// Main chatbot class that handles all cybersecurity awareness interactions.
    /// Includes ASCII art, user personalisation, response system, and input validation.
    /// </summary>
    public class Chatbot
    {
        // Stores the user's name for personalised responses
        private string userName;

        // Stores the user's interest area (for memory feature - to be expanded)
        private string userInterest;

        /// <summary>
        /// Starts the chatbot application.
        /// This is the main entry point called from Program.cs.
        /// </summary>
        public void Start()
        {
            DisplayAsciiArt();
            AskUserName();
            PersonalisedGreeting();
            MainConversationLoop();
        }

        /// <summary>
        /// Displays the ASCII art logo in cyan colour.
        /// Creates a visual header that welcomes users to the chatbot.
        /// </summary>
        private void DisplayAsciiArt()
        {
            // Set console text colour to cyan for visual appeal
            Console.ForegroundColor = ConsoleColor.Cyan;

            // ASCII art representing a shield/cybersecurity theme
            string asciiArt = @"
    ╔══════════════════════════════════════════════════════╗
    ║     ██████╗██╗   ██╗██████╗ ███████╗██████╗          ║
    ║    ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗         ║
    ║    ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝         ║
    ║    ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗         ║
    ║    ╚██████╗   ██║   ██████╔╝███████╗██║  ██║         ║
    ║     ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝         ║
    ║                                                      ║
    ║         CYBERSECURITY AWARENESS CHATBOT              ║
    ║            Stay Safe Online, South Africa!           ║
    ╚══════════════════════════════════════════════════════╝";

            Console.WriteLine(asciiArt);

            // Reset colour back to default
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Asks the user for their name and validates input.
        /// Ensures name is not empty or whitespace before proceeding.
        /// </summary>
        private void AskUserName()
        {
            Console.Write("Please enter your name: ");
            userName = Console.ReadLine();

            // Input validation: loop until valid name is provided
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.Write("Name cannot be empty. Please enter your name: ");
                userName = Console.ReadLine();
            }
        }

        /// <summary>
        /// Displays a personalised welcome message using the user's name.
        /// Uses green text for positive, welcoming tone.
        /// </summary>
        private void PersonalisedGreeting()
        {
            // Green text for positive greeting
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nHello, {userName}! Welcome to CyberAware SA.");
            Console.ResetColor();

            Console.WriteLine("I'm your cybersecurity awareness assistant. I'm here to help you stay safe online.");
            Console.WriteLine("You can ask me about password safety, phishing, safe browsing, or just say 'help'.\n");
        }

        /// <summary>
        /// Main conversation loop that continuously processes user input.
        /// Handles input validation and routes to the response system.
        /// Exits when user types 'exit' or 'quit'.
        /// </summary>
        private void MainConversationLoop()
        {
            string input;

            Console.WriteLine("Type 'help' at any time to see what I can do.\n");

            do
            {
                // Display prompt with user's name for personalised interaction
                Console.Write($"{userName}: ");
                input = Console.ReadLine()?.ToLower().Trim();

                // Input validation: handle empty input gracefully
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Chatbot: I didn't quite understand that. Could you rephrase?");
                    Console.ResetColor();
                    continue;
                }

                RespondToUser(input);

            } while (input != "exit" && input != "quit");
        }

        /// <summary>
        /// Processes user input and generates appropriate responses.
        /// Uses keyword matching to determine the topic and provide relevant cybersecurity advice.
        /// </summary>
        /// <param name="input">The user's input message, converted to lowercase.</param>
        private void RespondToUser(string input)
        {
            // Display "Chatbot:" in cyan for visual distinction
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Chatbot: ");
            Console.ResetColor();

            // Keyword-based response system
            if (input.Contains("how are you"))
            {
                Console.WriteLine($"I'm doing great, {userName}! Thanks for asking. I'm excited to help you learn about cybersecurity.");
            }
            else if (input.Contains("purpose") || input.Contains("what can you do"))
            {
                Console.WriteLine("My purpose is to educate South African citizens about online safety. I can teach you about passwords, phishing, and safe browsing!");
            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("Strong passwords should be at least 12 characters, include numbers, symbols, uppercase, and lowercase. Never reuse passwords across different sites!");
            }
            else if (input.Contains("phish"))
            {
                Console.WriteLine("Phishing emails often have urgent language, spelling errors, and suspicious links. Always check the sender's email address before clicking anything!");
            }
            else if (input.Contains("scam") || input.Contains("fraud"))
            {
                Console.WriteLine("Scammers often create fake urgency. Never share your OTP or PIN with anyone, even if they claim to be from your bank!");
            }
            else if (input.Contains("browsing") || input.Contains("safe browsing"))
            {
                Console.WriteLine("Look for 'https://' and a padlock icon in the address bar. Avoid clicking on pop-up ads and never enter personal info on unsecured sites.");
            }
            else if (input.Contains("help"))
            {
                Console.WriteLine("You can ask me about: passwords, phishing, safe browsing, scams, my purpose, or how I'm doing. Type 'exit' to quit.");
            }
            else if (input.Contains("exit") || input.Contains("quit"))
            {
                Console.WriteLine($"Goodbye, {userName}! Stay safe online!");
            }
            else
            {
                // Default fallback for unrecognised input (graceful error handling)
                Console.WriteLine("I didn't quite understand that. Could you rephrase? Try asking about passwords, phishing, safe browsing, or scams.");
            }

            Console.WriteLine();
        }
    }
}