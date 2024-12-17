using System;
namespace GameTaskPerformanceNamespace
{
    public class GameCreditClass
    {
        public void Credit()
        {
            static void Print(string text, int Sleep = 50)
            {
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(Sleep);
                }
                Console.WriteLine();
            }
            Console.Clear();
            Console.WriteLine("Credits");
            Print("Neri-Zon Bagabaldo: \nLeader of ST-EA SPORTS\nProgrammerist\nLead Coder");
            Print("Insert Motivational Speech KEK\n");
            Print("Ralph Benedict Mariano: \nMember of ST-EA SPORTS\nPancit Canton\nCo-Coder");
            Print("Insert Motivational Speech KEK\n");
            Print("Ryan Jedrick Co: \nSecretary of ST-EA SPORTS\nDocumentationist\nLead Wapakels");
            Print("Insert Motivational Speech KEK\n");
            Console.ReadKey();

            string response = string.Empty;
            while (response != "1" && response != "2")
            {
                Console.WriteLine("\nWould you like to return to the main menu?");
                Console.WriteLine("[1] Yes");
                Console.WriteLine("[2] No");
                response = Console.ReadLine().Trim();

                if (response == "1")
                {
                    Console.Clear();
                    MainMenu.Main(new string[] { });
                    return;
                }
                else if (response == "2")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input! ");
                }
            }
        }
    }
}