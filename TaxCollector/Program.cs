using System.Runtime.CompilerServices;

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
