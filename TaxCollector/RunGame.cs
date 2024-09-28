using System.Security.Cryptography.X509Certificates;

class RunGame {
    Calculations calculations = new Calculations();
    string[] numbers = Enumerable.Range(1, 50).Select(i => i.ToString()).ToArray();
    HashSet<int> pickedNumbers = new HashSet<int>();
    List<int> taxCollectorGains = new List<int>();

    //This is the main function for the game
    public void Play() {
        while (pickedNumbers.Count < numbers.Length) {
            DisplayScores();
            DisplayArray(numbers);

            Console.Write("\nPick a number: ");
            string input = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(input)) {
                Console.WriteLine("Please pick a valid number.");
                continue;
            }
            Console.Clear();

            int pickedNumber;
            if (!int.TryParse(input, out pickedNumber) || pickedNumber < 1 || pickedNumber > 50 || pickedNumbers.Contains(pickedNumber)) {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 50 that has not been picked.");
                continue;
            }

            if (!calculations.IsValidPick(pickedNumber, numbers)) {
                Console.WriteLine("This number would not give the tax collector any points. Please pick another number.");
                continue;
            }

            calculations.SetUserScore(pickedNumber);
            Console.WriteLine($"You Gained: {pickedNumber}");

            foreach (int factor in calculations.GetFactors(pickedNumber)) {
                if (factor != pickedNumber && numbers.Contains(factor.ToString())) {
                    calculations.SetCollectorScore(factor);
                    taxCollectorGains.Add(factor);
                    numbers[Array.IndexOf(numbers, factor.ToString())] = " ";
                    pickedNumbers.Add(factor);
                }
            }

            numbers[pickedNumber - 1] = " ";
            pickedNumbers.Add(pickedNumber);

            for (int i = 0; i < numbers.Length; i++) {
                if (numbers[i] != " " && !calculations.CheckFactors(int.Parse(numbers[i]), numbers)) {
                    int number = int.Parse(numbers[i]);
                    calculations.SetCollectorScore(number);
                    taxCollectorGains.Add(number);
                    numbers[i] = " ";
                    pickedNumbers.Add(i + 1);
                }
            }

            if (taxCollectorGains.Count > 0) {
                Console.WriteLine($"Tax Collector Gained: {string.Join(", ", taxCollectorGains)}");
            }

            if (pickedNumbers.Count >= numbers.Length) {
                FinalScore();
                break;
            }
            taxCollectorGains.Clear();
            Console.Write("Press Enter to Continue:");
            Console.ReadLine();
            Console.Clear();    
        }
    }

    //AI Assisted: This functtion displays each value in the array, grouping them in rows of 10 and spacing apart each value
    private void DisplayArray(string[] array) {
        for (int i = 0; i < array.Length; i++) {
            Console.Write($"{array[i],3}");
            if ((i + 1) % 10 == 0) {
                Console.WriteLine();
            }
        }
    }

    //This function displays the user's and Tax Collector's score
    private void DisplayScores() {
        int _userScore = calculations.GetUserScore();
        int _taxCollectorScore = calculations.GetCollectorScore();
        Console.WriteLine($"Your Score: {_userScore}");
        Console.WriteLine($"Tax Collector's Score: {_taxCollectorScore}");
    }

    //This function determines who wins the game and displays the results
    private void FinalScore() {
        int _userScore = calculations.GetUserScore();
        int _taxCollectorScore = calculations.GetCollectorScore();
        Console.Clear();
        Console.WriteLine($"Final User's score: {_userScore}");
        Console.WriteLine($"Final Tax Collector's score: {calculations.GetCollectorScore}");

        if (_userScore > _taxCollectorScore) {
            Console.WriteLine("Congratulations! You won!");
        }
        else if (_userScore < _taxCollectorScore) {
            Console.WriteLine("You lost! Better luck next time.");
        }
        else {
            Console.WriteLine("It's a tie!");
        }

        Console.Write("\nPress 'Enter' to return to the menu:");
        Console.ReadLine();          
    }
    
    //This function displays the rules of the game
    public static void DisplayRules() {
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

        