using System;
using System.Security.Cryptography.X509Certificates;

namespace GameTaskPerformanceNamespace
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string str) : base(str) { } //constructors
    }

    public class MainMenu
    {
        public static void Main(string[] args)
        {
            string prompt = @" █████   █████                                                   █████   
░░███   ░░███                                                   ░░███    
 ░███    ░███   ██████   ████████  █████ █████  ██████   █████  ███████  
 ░███████████  ░░░░░███ ░░███░░███░░███ ░░███  ███░░███ ███░░  ░░░███░   
 ░███░░░░░███   ███████  ░███ ░░░  ░███  ░███ ░███████ ░░█████   ░███    
 ░███    ░███  ███░░███  ░███      ░░███ ███  ░███░░░   ░░░░███  ░███ ███
 █████   █████░░████████ █████      ░░█████   ░░██████  ██████   ░░█████ 
░░░░░   ░░░░░  ░░░░░░░░ ░░░░░        ░░░░░     ░░░░░░  ░░░░░░     ░░░░░  
                                                                         
                                                                         
                                                                         
 █████   █████                                                           
░░███   ░░███                                                            
 ░███    ░███   ██████   █████ █████  ██████  ████████                   
 ░███████████  ░░░░░███ ░░███ ░░███  ███░░███░░███░░███                  
 ░███░░░░░███   ███████  ░███  ░███ ░███████  ░███ ░███                  
 ░███    ░███  ███░░███  ░░███ ███  ░███░░░   ░███ ░███                  
 █████   █████░░████████  ░░█████   ░░██████  ████ █████                 
░░░░░   ░░░░░  ░░░░░░░░    ░░░░░     ░░░░░░  ░░░░ ░░░░░                  ";
            Console.WriteLine(prompt);


            ShowLoad();
            Console.Clear();

            string logo = @"░█░█░█▀█░█▀▄░█░█░█▀▀░█▀▀░▀█▀░░░█░█░█▀█░█░█░█▀▀░█▀█
░█▀█░█▀█░█▀▄░▀▄▀░█▀▀░▀▀█░░█░░░░█▀█░█▀█░▀▄▀░█▀▀░█░█
░▀░▀░▀░▀░▀░▀░░▀░░▀▀▀░▀▀▀░░▀░░░░▀░▀░▀░▀░░▀░░▀▀▀░▀░▀";
            Console.WriteLine(logo);
            Console.WriteLine("[1]NEW GAME");
            Console.WriteLine("[2]LOAD GAME");
            Console.WriteLine("[3]CAMPAIGN MODE");
            Console.WriteLine("[4]CREDITS");
            Console.WriteLine("[5]EXIT\n");

            bool condition = true; // Main loop condition
            CharacterDet.NewGameClass newGameObj = new CharacterDet.NewGameClass();
            GameCreditClass newCreditObj = new GameCreditClass();
            CampaignClass newCampaignObj = new CampaignClass();
            LoadGameClass newLoadGameClass = new LoadGameClass();
            while (condition)
            {
                try
                {
                    Console.Write("Type your option (1-5): ");
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            newGameObj.AllMethodCall();
                            condition = false;
                            break;
                        case 2:
                            newLoadGameClass.LoadGamePrompt();
                            condition = false;
                            break;
                        case 3:
                            newCampaignObj.Campaign();
                            condition = false;
                            break;
                        case 4:
                            newCreditObj.Credit();
                            condition = false;
                            break;
                        case 5:
                            Console.WriteLine("Exiting program...");
                            condition = false;
                            break;
                        default:
                            throw new InvalidInputException("Invalid option! Please choose between 1 and 5.");
                    }

                }
                catch (InvalidInputException e) //exeption 
                {
                    Console.WriteLine($"Error: {e.Message}\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid format! Please enter a number between 1 and 5.\n");
                }
            }
        }
        public static void ShowLoad()
        {
            int total = 50;
            int progress = 0;
            string empty = new string(' ', total);
            string filled = new string('█', total);

            Console.Write("Loading: ");
            Console.Write(empty);
            Console.Write(" 0%");
            Console.SetCursorPosition(10, Console.CursorTop);

            Random random = new Random();

            for (int i = 0; i <= total; i++)
            {
                int randoms = random.Next(50, 80);
                Thread.Sleep(randoms);
                progress = (int)((float)i / total * 100);


                Console.Write(new string('█', i));
                Console.Write(new string(' ', total - i));
                Console.Write(progress + "%");
                Console.SetCursorPosition(10, Console.CursorTop);
            }
        }
    }
}