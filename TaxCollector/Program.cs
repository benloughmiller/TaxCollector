using System.Runtime.CompilerServices;

class Program {
    static void Main(string[] args) {
        while (true) {
            Console.Clear();
            string choice = "";
            Console.WriteLine("1. Play Game");
            Console.WriteLine("2. Rules");
            Console.WriteLine("3. Quit");
            Console.Write("Select an option: ");
            choice = Console.ReadLine()!;
            Console.Clear();

            switch (choice) {
                case "1":
                    Console.Write("Please enter a maximum number for the game's range: ");
                    string input = Console.ReadLine()!;
                    while (true) {
                        if (int.TryParse(input, out int maxInput) && maxInput != 1) {
                            new RunGame(maxInput);
                            break;
                        }
                        else {
                            Console.Write("Invalid input. Please enter a valid number:");
                            input = Console.ReadLine()!;
                        }
                    }
                    break;
                case "2":
                    RunGame.DisplayRules();
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
    }
}
