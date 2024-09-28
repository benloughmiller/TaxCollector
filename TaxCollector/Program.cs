class Program {
    static void Main(string[] args) {
        while (true) {
            string choice = "";
            Console.Clear();
            Console.WriteLine("1. Play Game");
            Console.WriteLine("2. Rules");
            Console.WriteLine("3. Quit");
            Console.Write("Select an option: ");
            choice = Console.ReadLine()!;
            Console.Clear();

            switch (choice) {
                case "1":
                    RunGame runGame = new RunGame();
                    runGame.Play();
                    break;
                case "2":
                    DisplayRules();
                    break;
                case "3":
                    Console.WriteLine("Press 'Enter' to exit the game:");
                    Console.ReadLine();
                    return;
                
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
        static void DisplayRules() {
            Console.Clear();
            Console.WriteLine("Rules:");
            Console.WriteLine("1. Each turn, you pick a number from 1 to 50.");
            Console.WriteLine("2. You gain points equal to the number you pick.");
            Console.WriteLine("3. The tax collector gains points equal to the factors of the picked number that are still available.");
            Console.WriteLine("4. The selected number and its factors are removed from the game.");
            Console.WriteLine("5. If a number has no remaining factors, its point value is given to the tax collector and is removed from the game.");
            Console.WriteLine("6. The game ends when all numbers have been picked or removed.");
            Console.WriteLine("7. Whoever has the highest score at the end wins.");
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
    }
}
