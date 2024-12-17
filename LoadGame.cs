using System;
using System.Data.SqlClient;
using GameTaskPerformanceNamespace;

public class LoadGameClass
{
    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\renzo\OneDrive\Desktop\dict\GameCharaCreation\GameCharaCreation\Database1.mdf;Integrated Security=True";

    public void LoadGamePrompt()
    {
        try
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] View specific characters\n[2] View all character\n[3] Delete Character \n[4] Main Menu\n[5] Exit");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Press Enter to try again.");
                    Console.ReadLine();
                }

                if (input == "1")
                {
                    LoadCharacter();
                }
                else if (input == "2")
                {
                    ViewAllCharacters();
                }
                else if (input == "3")
                {
                    DeleteCharacter();
                }
                else if (input == "4")
                {
                    Returning();
                }
                else if (input == "5")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Press Enter to try again.");
                    Console.ReadLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void LoadCharacter()
    {
        string[] characters = GetSavedCharacters();
        if (characters.Length == 0)
        {
            Console.WriteLine("No characters found. Press Enter to return.");
            Console.ReadLine();
            return;
        }

        DisplayCharacterList(characters);

        Console.Write("Enter the number of the character to load: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int index) && index > 0 && index <= characters.Length)
        {
            Console.WriteLine($"Loading data for {characters[index - 1]}...");
            DisplayCharacterDetails(characters[index - 1]);
        }
        else
        {
            Console.WriteLine("Invalid selection. Press Enter to return.");
            Console.ReadLine();
        }
    }

    public void ViewAllCharacters()
    {
        string[] characters = GetSavedCharacters();
        if (characters.Length == 0)
        {
            Console.WriteLine("No characters found. Press Enter to return.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("\nAll Saved Characters:");
        foreach (string charName in characters)
        {
            DisplayCharacterDetails(charName);
        }

        Console.WriteLine("Press Enter to return.");
        Console.ReadLine();
    }

    public void DeleteCharacter()
    {
        string[] characters = GetSavedCharacters();
        if (characters.Length == 0)
        {
            Console.WriteLine("No characters to delete. Press Enter to return.");
            Console.ReadLine();
            return;
        }

        DisplayCharacterList(characters);

        Console.Write("Enter the number of the character to delete (or 0 to delete all): ");
        string input = Console.ReadLine();
        if (input == "0")
        {
            Console.Write("Are you sure you want to delete ALL characters? (YES/NO): ");
            string confirmation = Console.ReadLine();
            if (confirmation?.ToLower() == "yes")
            {
                DeleteAllCharacters();
                Console.WriteLine("All characters deleted. Press Enter to return.");
            }
            else
            {
                Console.WriteLine("Action cancelled. Press Enter to return.");
            }
            Console.ReadLine();
        }
        else if (int.TryParse(input, out int index) && index > 0 && index <= characters.Length)
        {
            Console.Write($"Are you sure you want to delete {characters[index - 1]}? (YES/NO): ");
            string confirmation = Console.ReadLine();
            if (confirmation?.ToLower() == "yes")
            {
                DeleteCharacter(characters[index - 1]);
                Console.WriteLine($"{characters[index - 1]} deleted. Press Enter to return.");
            }
            else
            {
                Console.WriteLine("Action cancelled. Press Enter to return.");
            }
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Invalid selection. Press Enter to return.");
            Console.ReadLine();
        }
    }

    public string[] GetSavedCharacters()
    {
        var characters = new System.Collections.Generic.List<string>();

        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();
            string query = "SELECT name FROM savedcharainfo";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        characters.Add(reader["name"].ToString());
                    }
                }
            }
        }

        return characters.ToArray();
    }

    public void DisplayCharacterList(string[] characters)
    {
        Console.WriteLine("\nSaved Characters:");
        for (int i = 0; i < characters.Length; i++)
        {
            Console.WriteLine($"[{i + 1}] {characters[i]}");
        }
    }

    public void DisplayCharacterDetails(string name)
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();
            string query = "SELECT * FROM savedcharainfo WHERE name = @name";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@name", name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine("\nCharacter Details:");
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine($"{reader.GetName(i)}: {reader[i]}");
                        }
                    }
                }
            }
        }
        Console.WriteLine("\nPress Enter to continue.");
        Console.ReadKey();
    }

    public void DeleteCharacter(string name)
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();
            string query = "DELETE FROM savedcharainfo WHERE name = @name";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteAllCharacters()
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();
            string query = "DELETE FROM savedcharainfo";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public void Returning()
    {
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
