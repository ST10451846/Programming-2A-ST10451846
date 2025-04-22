using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_POE
{
    internal class Program
    {
        static void Main()
        {
            // Play audio greeting
            PlayWelcomeAudio("Welcome_greeting.wav");

            Console.Title = "Cybersecurity Awareness Chatbot";
            Console.ForegroundColor = ConsoleColor.Green;


            Console.WriteLine(@"

   _______     ______  ______ _____  _____  ______ ______ ______ _   _ _____  ______ _____   _____ 
  / ____\ \   / /  _ \|  ____|  __ \|  __ \|  ____|  ____|  ____| \ | |  __ \|  ____|  __ \ / ____|
 | |     \ \_/ /| |_) | |__  | |__) | |  | | |__  | |__  | |__  |  \| | |  | | |__  | |__) | (___  
 | |      \   / |  _ <|  __| |  _  /| |  | |  __| |  __| |  __| | . ` | |  | |  __| |  _  / \___ \ 
 | |____   | |  | |_) | |____| | \ \| |__| | |____| |    | |____| |\  | |__| | |____| | \ \ ____) |
  \_____|  |_|  |____/|______|_|  \_\_____/|______|_|    |______|_| \_|_____/|______|_|  \_\_____/ 
                                                                                                   
                                                                                                   

          [  CBS BOT - Your Cybersecurity Buddy! ]

        ");
            // Ask for user's name
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("What's your name? ");
            string userName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nHello, {userName}! I'm CBS Bot — your Cybersecurity Awareness Buddy.");
            Console.WriteLine("Ask me about password safety, phishing, safe browsing, or type 'exit' to quit.\n");

            // This is a while loop that keeps the chatbot running.
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"\n{userName}: ");
                string userInput = Console.ReadLine()?.ToLower().Trim();

                // It allows the user to ask multiple questions until they type 'exit'.
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("CBS BOT: Please enter a valid question.");
                    continue;
                }

                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("CBS BOT: Thanks for chatting! Stay cyber safe.");
                    break;
                }

                HandleUserQuery(userInput, userName);
            }

        }
        static void PlayWelcomeAudio(string fileName)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                if (File.Exists(path))
                {
                    SoundPlayer player = new SoundPlayer(path);
                    player.PlaySync(); // ensures that the audio is in sync
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Audio file '{fileName}' not found."); // if audio can't be found
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error playing audio: {ex.Message}"); // An error has occured in the audio
            }
        }

        static void HandleUserQuery(string input, string userName)
        {
            // Normalize common phrases to known topics
            if (input.Contains("password"))
                input = "password safety";
            else if (input.Contains("browsing"))
                input = "safe browsing";
            else if (input.Contains("how are you"))
                input = "how are you";
            else if (input.Contains("purpose"))
                input = "purpose of bot";
            else if (input.Contains("cybersecurity"))
                input = "what is cybersecurity";

            Dictionary<string, string> responses = new Dictionary<string, string>
            {
                { "help", "Topics like 'password safety', 'phishing', or 'safe browsing'. Just type any of those!" },
                { "password safety", "Use a strong password with letters, numbers, and symbols. Avoid using the same password on multiple sites!" },
                { "phishing", "Phishing is a trick where attackers pretend to be trusted sources. Always double-check email addresses and links!" },
                { "safe browsing", "Keep your software updated, avoid suspicious sites, and never click on pop-up ads!" },
                { "how are you", "I'm running perfectly, thanks for asking! How can I assist you with cybersecurity today?" },
                { "purpose of bot", "My purpose is to assist you with cybersecurity awareness. I provide tips on safe online practices!" },
                { "what is cybersecurity", "Cybersecurity is the practice of protecting systems, networks, and data from digital attacks, theft, and damage." }
            };

            if (responses.ContainsKey(input))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine($"CBS BOT: {responses[input]}");
                Console.WriteLine("----------------------------------------");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine($"CBS BOT: Hmm... I’m not sure about that, {userName}. Would you like me to suggest a cybersecurity tip? (yes/no)");
                Console.WriteLine("----------------------------------------");

                string reply = Console.ReadLine()?.ToLower().Trim();

                if (reply == "yes")
                {
                    SuggestCyberTips(); // Still calling your tip suggestion method
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n----------------------------------------");
                    Console.WriteLine("CBS BOT: No worries! You can ask about password safety, phishing, or safe browsing.");
                    Console.WriteLine("----------------------------------------");
                }
            }
        }

        static void SuggestCyberTips()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("CBS BOT: What area do you want a tip on? (password/phishing/browsing)");

            Console.ForegroundColor = ConsoleColor.White;
            string topic = Console.ReadLine()?.ToLower().Trim();

            Console.ForegroundColor = ConsoleColor.Green;
            if (topic == "password")
            {
                Console.WriteLine("Cyber Tip: Use a password manager to keep your credentials secure and never share your passwords!");
            }
            else if (topic == "phishing")
            {
                Console.WriteLine("Cyber Tip: Don’t fall for urgent emails asking for login info. Always verify the sender.");
            }
            else if (topic == "browsing")
            {
                Console.WriteLine("Cyber Tip: Use incognito mode when necessary and always log out from public computers.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CBS BOT: That topic isn't recognized. Try 'password', 'phishing', or 'browsing'.");
            }
        }

    }
}

