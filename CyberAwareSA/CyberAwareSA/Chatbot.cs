using System;
using System.Collections.Generic;

namespace CyberAwareSA
{
    /// <summary>
    /// Main chatbot class that handles all cybersecurity awareness interactions.
    /// Includes ASCII art, user personalisation, response system, input validation, memory, and sentiment detection.
    /// </summary>
    public class Chatbot
    {
        // Stores the user's name for personalised responses
        private string userName;

        // Stores the user's favourite cybersecurity topic
        private string userFavouriteTopic;

        // Dictionary to store user preferences and remembered information
        private Dictionary<string, string> userMemory;

        // Audio service for voice greeting
        private AudioService audio;    

        // UI helper for enhanced console interface
        private UIHelper ui;

        // Sentiment analyzer for emotion detection
        private SentimentAnalyzer sentimentAnalyzer;

        /// <summary>
        /// Constructor initialises the audio service, UI helper, memory storage, and sentiment analyzer.
        /// </summary>
        public Chatbot()
        {
            audio = new AudioService();
            ui = new UIHelper();
            sentimentAnalyzer = new SentimentAnalyzer();
            userMemory = new Dictionary<string, string>();
        }

        /// <summary>
        /// Starts the chatbot application.
        /// This is the main entry point called from Program.cs.
        /// </summary>
        public void Start()
        {
            audio.PlayGreeting();
            ui.DrawHeader();
            DisplayAsciiArt();
            AskUserName();
            StoreUserInMemory();
            AskFavouriteTopic();
            PersonalisedGreeting();
            MainConversationLoop();
        }

        /// <summary>
        /// Stores the user's name in memory for later use.
        /// </summary>
        private void StoreUserInMemory()
        {
            userMemory["name"] = userName;
        }

        /// <summary>
        /// Asks the user for their favourite cybersecurity topic and stores it in memory.
        /// </summary>
        private void AskFavouriteTopic()
        {
            ui.BotResponse("To help me personalise your experience, what cybersecurity topic interests you the most?");
            ui.InfoMessage("You can say: passwords, phishing, scams, safe browsing, or all topics");
            Console.Write($"{userName}: ");
            string topic = Console.ReadLine()?.ToLower().Trim();

            if (topic.Contains("password"))
            {
                userFavouriteTopic = "passwords";
                userMemory["favourite_topic"] = "passwords";
                ui.SuccessMessage("Great! I'll remember that you're interested in password safety.");
            }
            else if (topic.Contains("phish"))
            {
                userFavouriteTopic = "phishing";
                userMemory["favourite_topic"] = "phishing";
                ui.SuccessMessage("Great! I'll remember that you're interested in phishing awareness.");
            }
            else if (topic.Contains("scam") || topic.Contains("fraud"))
            {
                userFavouriteTopic = "scams";
                userMemory["favourite_topic"] = "scams";
                ui.SuccessMessage("Great! I'll remember that you're interested in scam detection.");
            }
            else if (topic.Contains("browsing"))
            {
                userFavouriteTopic = "safe browsing";
                userMemory["favourite_topic"] = "safe browsing";
                ui.SuccessMessage("Great! I'll remember that you're interested in safe browsing habits.");
            }
            else if (topic.Contains("all"))
            {
                userFavouriteTopic = "all topics";
                userMemory["favourite_topic"] = "all";
                ui.SuccessMessage("Great! I'll cover a wide range of cybersecurity topics for you.");
            }
            else
            {
                userFavouriteTopic = "general cybersecurity";
                userMemory["favourite_topic"] = "general";
                ui.InfoMessage("I'll share general cybersecurity tips with you. You can always ask me about specific topics!");
            }

            ui.DrawSeparator();
        }

        /// <summary>
        /// Displays the ASCII art logo in cyan colour.
        /// Creates a visual header that welcomes users to the chatbot.
        /// </summary>
        private void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

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

            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.Write("Name cannot be empty. Please enter your name: ");
                userName = Console.ReadLine();
            }
        }

        /// <summary>
        /// Displays a personalised welcome message using the user's name and remembered preferences.
        /// Uses green text for positive, welcoming tone.
        /// </summary>
        private void PersonalisedGreeting()
        {
            ui.SuccessMessage($"Welcome back, {userName}!");
            Console.WriteLine();
            ui.BotResponse($"I'm your cybersecurity awareness assistant. As someone interested in {userFavouriteTopic}, I'll focus on keeping you safe online.");
            ui.BotResponse("You can ask me about password safety, phishing, safe browsing, scams, or just say 'help'.");
            ui.DrawSeparator();
        }

        /// <summary>
        /// Main conversation loop that continuously processes user input.
        /// Handles input validation and routes to the response system.
        /// Exits when user types 'exit' or 'quit'.
        /// </summary>
        private void MainConversationLoop()
        {
            string input;

            ui.InfoMessage("Type 'help' at any time to see what I can do.");
            ui.DrawSeparator('─', ConsoleColor.DarkGray);
            Console.WriteLine();

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{userName}: ");
                Console.ResetColor();
                input = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    ui.WarningMessage("I didn't quite understand that. Could you rephrase?");
                    continue;
                }

                RespondToUser(input);

            } while (input != "exit" && input != "quit");
        }

        /// <summary>
        /// Processes user input and generates appropriate responses.
        /// Uses keyword matching, remembers user preferences, and detects sentiment for empathetic responses.
        /// </summary>
        /// <param name="input">The user's input message, converted to lowercase.</param>
        private void RespondToUser(string input)
        {
            // Detect sentiment first
            string sentiment = sentimentAnalyzer.DetectSentiment(input);

            // Get empathetic response if sentiment is emotional
            string empatheticResponse = sentimentAnalyzer.GetEmpatheticResponse(sentiment, userName);
            if (empatheticResponse != null)
            {
                ui.BotResponse(empatheticResponse);
            }

            // Keyword-based response system
            if (input.Contains("how are you"))
            {
                ui.BotResponse($"I'm doing great, {userName}! Thanks for asking. I'm excited to help you learn about {userFavouriteTopic}.");
            }
            else if (input.Contains("remember me") || input.Contains("what do you know about me"))
            {
                ui.BotResponse($"I remember that your name is {userMemory["name"]} and you're interested in {userFavouriteTopic}. Is there anything specific you'd like to learn about today?");
            }
            else if (input.Contains("purpose") || input.Contains("what can you do"))
            {
                ui.BotResponse("My purpose is to educate South African citizens about online safety. I can teach you about passwords, phishing, safe browsing, and scams!");
            }
            else if (input.Contains("password"))
            {
                ui.BotResponse("Strong passwords should be at least 12 characters, include numbers, symbols, uppercase, and lowercase. Never reuse passwords across different sites!");

                // Personalised follow-up based on memory
                if (userFavouriteTopic == "passwords")
                {
                    ui.BotResponse($"Since you're interested in password safety, {userName}, would you like me to share tips on creating a strong master password?");
                }

                // Provide supportive tip if user is worried or frustrated
                string supportiveTip = sentimentAnalyzer.GetSupportiveTip("password", sentiment);
                if (supportiveTip != null)
                {
                    ui.InfoMessage(supportiveTip);
                }
            }
            else if (input.Contains("phish"))
            {
                ui.BotResponse("Phishing emails often have urgent language, spelling errors, and suspicious links. Always check the sender's email address before clicking anything!");

                string supportiveTip = sentimentAnalyzer.GetSupportiveTip("phish", sentiment);
                if (supportiveTip != null)
                {
                    ui.InfoMessage(supportiveTip);
                }
            }
            else if (input.Contains("scam") || input.Contains("fraud"))
            {
                ui.BotResponse("Scammers often create fake urgency. Never share your OTP or PIN with anyone, even if they claim to be from your bank!");

                string supportiveTip = sentimentAnalyzer.GetSupportiveTip("scam", sentiment);
                if (supportiveTip != null)
                {
                    ui.InfoMessage(supportiveTip);
                }
            }
            else if (input.Contains("browsing") || input.Contains("safe browsing"))
            {
                ui.BotResponse("Look for 'https://' and a padlock icon in the address bar. Avoid clicking on pop-up ads and never enter personal info on unsecured sites.");
            }
            else if (input.Contains("help"))
            {
                ui.BotResponse($"You can ask me about: passwords, phishing, safe browsing, scams, my purpose, or how I'm doing. You can also ask 'what do you know about me' to see what I remember. Type 'exit' to quit.");
            }
            else if (input.Contains("exit") || input.Contains("quit"))
            {
                ui.BotResponse($"Goodbye, {userName}! Stay safe online! Remember to use strong passwords and stay alert for phishing attempts.");
            }
            else if (!input.Contains("how are you") && !input.Contains("purpose") && !input.Contains("help") &&
                     !input.Contains("password") && !input.Contains("phish") && !input.Contains("scam") &&
                     !input.Contains("browsing") && !input.Contains("remember me") && !input.Contains("exit"))
            {
                // Default fallback for unrecognised input (graceful error handling)
                if (sentiment == "worried")
                {
                    ui.BotResponse("I understand this might feel overwhelming. Let's start simple. Try asking me about 'passwords' or 'phishing' and I'll give you easy tips to stay safe.");
                }
                else if (sentiment == "frustrated")
                {
                    ui.BotResponse("I hear you. Let me make this easier. Just type 'help' and I'll show you some simple things we can talk about.");
                }
                else
                {
                    ui.WarningMessage("I didn't quite understand that. Could you rephrase? Try asking about passwords, phishing, safe browsing, or scams.");
                }
            }

            ui.DrawSeparator('─', ConsoleColor.DarkGray);
        }
    }
}