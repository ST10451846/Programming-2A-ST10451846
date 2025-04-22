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

        }
    }
}
