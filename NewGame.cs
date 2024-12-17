using System;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace GameTaskPerformanceNamespace
{

    public interface CharacterCustom
    {
        void NewGameCharaDetails();
        void NewGameCharaAppearance();
        void NewGameCharaAttire();
        void NewGameCharaStats();
        void NewGameBoolean();
        void UserCharacterAppearance();
    }

    public abstract class BaseClass : CharacterCustom
    {
        public abstract void NewGameCharaDetails();
        public abstract void NewGameCharaAppearance();
        public abstract void NewGameCharaAttire();
        public abstract void NewGameCharaStats();
        public abstract void NewGameBoolean();
        public abstract void UserCharacterAppearance();
    }

    public struct CharacterDet
    {
        public String Name;
        public String Gender;
        public String SkinColor;
        public String EyeColor;
        public String HairStyle;
        public String HairColor;
        public String BeardStyle;
        public String UpperClothes;
        public String LowerClothes;
        public String Footwear;
        public String Accessories;

        public override string ToString()
        {
            return $"Name: {Name}\nGender: {Gender}\nSkin Color: {SkinColor}\nEye Color: {EyeColor}\n" +
               $"Hair Style: {HairStyle}\nHair Color: {HairColor}\nBeard Style: {BeardStyle}\n" +
               $"Upper Clothes: {UpperClothes}\nLower Clothes: {LowerClothes}\nFootwear: {Footwear}\n" +
               $"Accessories: {Accessories}";
        }

        public class NewGameClass : BaseClass
        {

            public class InvalidInputException : Exception
            {
                public InvalidInputException(string str) : base(str) { }
            }

            private string input;
            private CharacterDet charaDetails = new CharacterDet();
            private int initialPoints = 10;
            private int basePoints = 5;
            private int[] baseNumberStats = { 0, 0, 0, 0, 0, 0, 0 };
            private string[] characterStats = { "Woodcutting", "Mining", "Crafting", "Fishing", "Botany", "Hunting", "Farming" };
            private bool horsePet;
            private bool isMarried;

            public NewGameClass()
            {
                this.input = string.Empty;
                this.initialPoints = 10;
            }
            public NewGameClass(string input, int initialPoints = 10, int basePoints = 5)
            {
                this.input = input;
                this.initialPoints = initialPoints;
                this.basePoints = basePoints;
            }
            public void GameClass(string input, int initialPoints = 10, int basePoints = 5)
            {
                this.input = input;
                this.initialPoints = initialPoints;
            }
            public void GameClass(string input)
            {
                this.input = input;
                this.initialPoints = 10;
            }

            public void GameClass(string input, int points)
            {
                this.input = input;
                this.initialPoints = points;
            }

            public void AllMethodCall()
            {
                NewGameCharaDetails();
                NewGameCharaAppearance();
                NewGameCharaAttire();
                NewGameCharaStats();
                NewGameBoolean();
                UserCharacterAppearance();
            }


            public override void NewGameCharaDetails()
            {
                while (true)
                {
                    Console.Write("Enter Your Name (5-16 characters): ");
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input) || input.Length < 5 || input.Length > 16)
                    {
                        Console.WriteLine("Invalid Input! Try Again.");
                        continue;
                    }

                    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\renzo\OneDrive\Desktop\dict\GameCharaCreation\GameCharaCreation\Database1.mdf;Integrated Security=True";
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM SavedCharaInfo WHERE name = @name", sqlConnection);
                        command.Parameters.AddWithValue("@name", input);

                        if ((int)command.ExecuteScalar() > 0)
                        {
                            Console.WriteLine("This name is already taken.");
                            continue;
                        }
                    }

                    charaDetails.Name = input;
                    break;
                }

                Console.WriteLine("\nSelect Your Gender:");
                Console.WriteLine("[1] Male");
                Console.WriteLine("[2] Female");
                Console.WriteLine("[3] Transgender");
                Console.WriteLine("[4] Lesbian");
                Console.WriteLine("[5] Gay");
                Console.WriteLine("[6] Bisexual");
                Console.WriteLine("[7] Queer");
                Console.WriteLine("[8] Intersex");

                while (true)
                {
                    try
                    {
                        Console.Write("\nEnter your choice: ");
                        input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            throw new InvalidInputException("Value cannot be whitespace!");
                        }

                        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 8)
                        {
                            string[] genderOptions = { "Male", "Female", "Transgender", "Lesbian", "Gay", "Bisexual", "Queer", "Intersex" };
                            charaDetails.Gender = genderOptions[choice - 1];
                            break;
                        }
                        else
                        {
                            throw new InvalidInputException("Invalid input, try again!");
                        }
                    }
                    catch (InvalidInputException e)
                    {
                        Console.WriteLine($"Message: {e.Message}");
                    }
                }
            }

            public override void NewGameCharaAppearance()
            {
                Console.WriteLine("\nSelect Skin Color:");
                Console.WriteLine("[1] Pale");
                Console.WriteLine("[2] Beige");
                Console.WriteLine("[3] Tan");
                Console.WriteLine("[4] Espresso");
                Console.WriteLine("[5] Chocolate");

                while (true)
                {
                    try
                    {
                        Console.Write("\nEnter your choice: ");
                        input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            throw new InvalidInputException("Value cannot be whitespace!");
                        }

                        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 5)
                        {
                            string[] skinOptions = { "Pale", "Beige", "Tan", "Espresso", "Chocolate" };
                            charaDetails.SkinColor = skinOptions[choice - 1];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice! ");
                        }
                    }
                    catch (InvalidInputException e)
                    {
                        Console.WriteLine($"Message: {e.Message}");
                    }
                }

                Console.WriteLine("\nSelect Eye Color:");
                Console.WriteLine("[1] Blue");
                Console.WriteLine("[2] Brown");
                Console.WriteLine("[3] Black");
                Console.WriteLine("[4] Green");
                Console.WriteLine("[5] Pink");

                while (true)
                {
                    try
                    {
                        Console.Write("\nEnter your choice: ");
                        input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            throw new InvalidInputException("Value cannot be whitespace!");
                        }

                        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 5)
                        {
                            string[] eyeOptions = { "Blue", "Brown", "Black", "Green", "Pink" };
                            charaDetails.EyeColor = eyeOptions[choice - 1];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice! ");
                        }
                    }
                    catch (InvalidInputException e)
                    {
                        Console.WriteLine($"Message: {e.Message}");
                    }
                }

                Console.WriteLine("\nSelect Hair Style:");
                Console.WriteLine("[1] Burst Fade V CUT");
                Console.WriteLine("[2] Curly");
                Console.WriteLine("[3] Shaggy");
                Console.WriteLine("[4] Mohawks");
                Console.WriteLine("[5] Long Hair");
                Console.WriteLine("[6] Bald");

                while (true)
                {
                    try
                    {
                        Console.Write("\nEnter your choice: ");
                        input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            throw new InvalidInputException("Value cannot be whitespace!");
                        }

                        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 6)
                        {
                            string[] hairOptions = { "Burst Fade V CUT", "Curly", "Shaggy", "Mohawks", "Long Hair", "Bald" };
                            charaDetails.HairStyle = hairOptions[choice - 1];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice! ");
                        }
                    }
                    catch (InvalidInputException e)
                    {
                        Console.WriteLine($"Message: {e.Message}");
                    }
                }

                Console.WriteLine("\nSelect Hair Color:");
                Console.WriteLine("[1] Black");
                Console.WriteLine("[2] Brown");
                Console.WriteLine("[3] White");
                Console.WriteLine("[4] Pink");
                Console.WriteLine("[5] Violet");

                while (true)
                {
                    try
                    {
                        Console.Write("Enter your choice: ");
                        input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            throw new InvalidInputException("Value cannot be whitespace!");
                        }

                        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 5)
                        {
                            string[] hairColorOptions = { "Black", "Brown", "White", "Pink", "Violet" };
                            charaDetails.HairColor = hairColorOptions[choice - 1];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice! ");
                        }
                    }
                    catch (InvalidInputException e)
                    {
                        Console.WriteLine($"Message: {e.Message}");
                    }
                }

                Console.WriteLine("\nSelect Beard Style:");
                Console.WriteLine("[1] No Beard");
                Console.WriteLine("[2] Goatee");
                Console.WriteLine("[3] Chevron");
                Console.WriteLine("[4] Circle Beard");
                Console.WriteLine("[5] Full Beard");

                while (true)
                {
                    try
                    {
                        Console.Write("Enter your choice: ");
                        input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            throw new InvalidInputException("Value cannot be whitespace!");
                        }

                        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 5)
                        {
                            string[] beardOptions = { "No Beard", "Goatee", "Chevron", "Circle Beard", "Full Beard" };
                            charaDetails.BeardStyle = beardOptions[choice - 1];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice! ");
                        }
                    }
                    catch (InvalidInputException e)
                    {
                        Console.WriteLine($"Message: {e.Message}");
                    }
                }
            }

            public override void NewGameCharaAttire()
            {
                Console.WriteLine("\nSelect Upper Clothes:");
                Console.WriteLine("[1] Long Sleeve");
                Console.WriteLine("[2] Jumper");
                Console.WriteLine("[3] T-shirt");
                Console.WriteLine("[4] Sleeveless");
                Console.WriteLine("[5] Tank Top");

                while (true)
                {
                    try
                    {
                        Console.Write("Enter your choice: ");
                        input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            throw new InvalidInputException("Value cannot be whitespace!");
                        }

                        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 5)
                        {
                            string[] upperClothesOptions = { "Long Sleeve", "Jumper", "T-shirt", "Sleeveless", "Tank Top" };
                            charaDetails.UpperClothes = upperClothesOptions[choice - 1];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice! ");
                        }
                    }
                    catch (InvalidInputException e)
                    {
                        Console.WriteLine($"Message: {e.Message}");
                    }
                }

                Console.WriteLine("\nSelect Lower Clothes:");
                Console.WriteLine("[1] Cargo Pants");
                Console.WriteLine("[2] Shorts");
                Console.WriteLine("[3] Long Pants");
                Console.WriteLine("[4] Cropped Pants");
                Console.WriteLine("[5] Jeans");

                while (true)
                {
                    try
                    {
                        Console.Write("Enter your choice: ");
                        input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            throw new InvalidInputException("Value cannot be whitespace!");
                        }

                        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 5)
                        {
                            string[] lowerClothesOptions = { "Cargo Pants", "Shorts", "Long Pants", "Cropped Pants", "Jeans" };
                            charaDetails.LowerClothes = lowerClothesOptions[choice - 1];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice! ");
                        }
                    }
                    catch (InvalidInputException e)
                    {
                        Console.WriteLine($"Message: {e.Message}");
                    }
                }

                Console.WriteLine("\nChoose Footwear:");
                Console.WriteLine("[1] Flip Flops");
                Console.WriteLine("[2] Sandals");
                Console.WriteLine("[3] Boots");
                Console.WriteLine("[4] Hiking Boots");
                Console.WriteLine("[5] Basketball Shoes");

                while (true)
                {
                    try
                    {
                        Console.Write("Enter your choice: ");
                        input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            throw new InvalidInputException("Value cannot be whitespace!");
                        }

                        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 5)
                        {
                            string[] footwearOptions = { "Flip Flops", "Sandals", "Boots", "Hiking Boots", "Basketball Shoes" };
                            charaDetails.Footwear = footwearOptions[choice - 1];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice! ");
                        }
                    }
                    catch (InvalidInputException e)
                    {
                        Console.WriteLine($"Message: {e.Message}");
                    }
                }

                Console.WriteLine("\nSelect Accessories:");
                Console.WriteLine("[1] Glasses");
                Console.WriteLine("[2] Farmer Hat");
                Console.WriteLine("[3] Gold Necklace");
                Console.WriteLine("[4] Balaclava");
                Console.WriteLine("[5] Halo");
                Console.WriteLine("[6] Wings");

                while (true)
                {
                    try
                    {
                        Console.Write("\nEnter your choice: ");
                        input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            throw new InvalidInputException("Value cannot be whitespace!");
                        }

                        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 6)
                        {
                            string[] accessoriesOptions = { "Glasses", "Farmer Hat", "Gold Necklace", "Balaclava", "Halo", "Wings" };
                            charaDetails.Accessories = accessoriesOptions[choice - 1];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice! ");
                        }
                    }
                    catch (InvalidInputException e)
                    {
                        Console.WriteLine($"Message: {e.Message}");
                    }
                }
            }

            public override void NewGameCharaStats()
            {
                Console.WriteLine("\nCharacter Stat Assign: (10 initial points to be divided among stats; max per stat is 5)");

                for (int i = 0; i < characterStats.Length; i++)
                {
                    Console.WriteLine($"Stats: {characterStats[i]} | Points: {baseNumberStats[i]}");
                }

                for (int i = 0; i < characterStats.Length; i++)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Write($"Assign stat points to {characterStats[i]}: ");

                            if (int.TryParse(Console.ReadLine(), out int statAssign) &&
                                statAssign >= 0 &&
                                statAssign <= (basePoints - baseNumberStats[i]) &&
                                statAssign <= initialPoints)
                            {
                                baseNumberStats[i] += statAssign;
                                initialPoints -= statAssign;
                                Console.WriteLine($"Total points for {characterStats[i]}: {baseNumberStats[i]} | Points left: {initialPoints}");
                                break;
                            }
                            else
                            {
                                throw new InvalidInputException("Invalid Value!");
                            }
                        }
                        catch (InvalidInputException e)
                        {
                            Console.WriteLine($"Message: {e.Message}");
                        }
                    }

                    if (initialPoints == 0)
                    {
                        Console.WriteLine("All points allocated.");
                        break;
                    }
                }
            }

            public override void NewGameBoolean()
            {
                while (true)
                {
                    Console.WriteLine("\n(Would you like to have a horse pet? (Max pet slot is one)");
                    Console.WriteLine("[1] Yes (Help you for fast travel: might be needed later in the story)");
                    Console.WriteLine("[2] No (You will have no companion for the start of the story, but exciting encounter awaits) " +
                        "\n[chance to encounter and tame exclusive pets]");
                    Console.Write("Enter your choice: ");
                    input = Console.ReadLine().ToLower();

                    try
                    {
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            throw new InvalidInputException("Value cannot be whitespace!");
                        }

                        if (input == "1" || input == "yes")
                        {
                            horsePet = true;
                            break;
                        }
                        else if (input == "2" || input == "no")
                        {
                            horsePet = false;
                            break;
                        }
                        else
                        {
                            throw new InvalidInputException("Wrong Input, Try again!");
                        }
                    }
                    catch (InvalidInputException e)
                    {
                        Console.WriteLine($"Message: {e.Message}");
                    }
                }

                while (true)
                {
                    Console.WriteLine("\nAre you married?");
                    Console.WriteLine("[1] Yes (Can help you with your task; couple is randomly selected)");
                    Console.WriteLine("[2] No (While single, earning is slightly increased; can select their couple by improving relationships)");
                    Console.Write("Enter your choice: ");
                    input = Console.ReadLine().ToLower();

                    try
                    {
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            throw new InvalidInputException("Value cannot be whitespace!");
                        }

                        if (input == "1" || input == "yes")
                        {
                            isMarried = true;
                            break;
                        }
                        else if (input == "2" || input == "no")
                        {
                            isMarried = false;
                            break;
                        }
                        else
                        {
                            throw new InvalidInputException("Wrong Input, Try again!");
                        }
                    }
                    catch (InvalidInputException e)
                    {
                        Console.WriteLine($"Message: {e.Message}");
                    }
                }
            }

            public override void UserCharacterAppearance()
            {
                Console.WriteLine("\nYour Character Customization Selection:");
                Console.WriteLine($"What is Your Name?: {charaDetails.Name}");
                Console.WriteLine($"What is your Gender?: {charaDetails.Gender}");
                Console.WriteLine($"Select Skin Color: {charaDetails.SkinColor}");
                Console.WriteLine($"Select Eye Color: {charaDetails.EyeColor}");
                Console.WriteLine($"Select Hair Style: {charaDetails.HairStyle}");
                Console.WriteLine($"What is Your Hair Color: {charaDetails.HairColor}");
                Console.WriteLine($"Select Beard Style: {charaDetails.BeardStyle}");
                Console.WriteLine($"Select Upper Clothes: {charaDetails.UpperClothes}");
                Console.WriteLine($"Select Lower Clothes: {charaDetails.LowerClothes}");
                Console.WriteLine($"Choose Footwear: {charaDetails.Footwear}");
                Console.WriteLine($"Select Accessories: {charaDetails.Accessories}");

                Console.WriteLine("\nCharacter Stats:");
                for (int i = 0; i < characterStats.Length; i++)
                {
                    Console.WriteLine($"{characterStats[i]}: {baseNumberStats[i]}");
                }
                Console.WriteLine($"\nPoints Remaining: {initialPoints}");

                Console.WriteLine($"Obtain Pet Horse?: {horsePet}");
                Console.WriteLine($"Are you married?: {isMarried}");
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
                        Database();
                        Console.Clear();
                        MainMenu.Main(new string[] { });
                        return;
                    }
                    else if (response == "2")
                    {
                        Database();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! ");
                    }
                }
            }
            public void Database()
            {
                SqlConnection sqlConnection;
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\renzo\OneDrive\Desktop\dict\GameCharaCreation\GameCharaCreation\Database1.mdf;Integrated Security=True";

                try
                {
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();

                    string insertQuery = @"
                    INSERT INTO SavedCharaInfo 
                    (name, gender, skin_Color, eye_Color, hairstyle, hair_Color, beard, 
                    u_Clothes, l_Clothers, footwear, accessories, 
                    woodcutting, mining, crafting, fishing, botany, hunting, farming, hasHorse, isMarried) 
                    VALUES 
                    (@name, @gender, @skinColor, @eyeColor, @hairstyle, @hairColor, @beard, 
                    @uClothes, @lClothes, @footwear, @accessories, 
                    @woodcutting, @mining, @crafting, @fishing, @botany, @hunting, @farming, @hasHorse, @isMarried)";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                    insertCommand.Parameters.AddWithValue("@name", charaDetails.Name);
                    insertCommand.Parameters.AddWithValue("@gender", charaDetails.Gender);
                    insertCommand.Parameters.AddWithValue("@skinColor", charaDetails.SkinColor);
                    insertCommand.Parameters.AddWithValue("@eyeColor", charaDetails.EyeColor);
                    insertCommand.Parameters.AddWithValue("@hairstyle", charaDetails.HairStyle);
                    insertCommand.Parameters.AddWithValue("@hairColor", charaDetails.HairColor);
                    insertCommand.Parameters.AddWithValue("@beard", charaDetails.BeardStyle);
                    insertCommand.Parameters.AddWithValue("@uClothes", charaDetails.UpperClothes);
                    insertCommand.Parameters.AddWithValue("@lClothes", charaDetails.LowerClothes);
                    insertCommand.Parameters.AddWithValue("@footwear", charaDetails.Footwear);
                    insertCommand.Parameters.AddWithValue("@accessories", charaDetails.Accessories);
                    insertCommand.Parameters.AddWithValue("@woodcutting", baseNumberStats[0]);
                    insertCommand.Parameters.AddWithValue("@mining", baseNumberStats[1]);
                    insertCommand.Parameters.AddWithValue("@crafting", baseNumberStats[2]);
                    insertCommand.Parameters.AddWithValue("@fishing", baseNumberStats[3]);
                    insertCommand.Parameters.AddWithValue("@botany", baseNumberStats[4]);
                    insertCommand.Parameters.AddWithValue("@hunting", baseNumberStats[5]);
                    insertCommand.Parameters.AddWithValue("@farming", baseNumberStats[6]);
                    insertCommand.Parameters.AddWithValue("@hasHorse", horsePet ? 1 : 0);
                    insertCommand.Parameters.AddWithValue("@isMarried", isMarried ? 1 : 0);

                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine("Input success!");
                    sqlConnection.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }


        }
    }
}