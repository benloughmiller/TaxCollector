class Calculations {
    private int userScore;
    private int collectorScore;
    public Calculations() {
        userScore = 0;
        collectorScore = 0;
    }


    //Allows other classes to access the current user score
    public int GetUserScore() {
        return userScore;
    }
    //Allows other classes to access the current tax collector score
    public int GetCollectorScore() {
        return collectorScore;
    }

    //Allows the game to update the user's score
    public void SetUserScore(int points) {
        userScore += points;
    }

    //allows the game to update the tax collector's score
    public void SetCollectorScore(int points) {
        collectorScore += points;
    }

    //This function gets the factors of a selected number
    //It checks each number, starting with one and ending with the selected number, and sees if there is any remainder when divided
    //The function individually returns each number that is found to be a factor
    public IEnumerable<int> GetFactors(int number) {
        for (int i = 1; i <= number; i++) {
            if (number % i == 0) {
                yield return i;
            }
        }
    }

    //This function validates the numbers in the array to ensure that they either have factors or are a factor of something
    //For example, as long as '1' remains in the array, all prime numbers should return true in this function
    //If a number no longer is a factor or has any factors, it returns false
    public bool CheckFactors(int number, string[] array) {
        foreach (int factor in GetFactors(number)) {
            if (factor != number && array.Contains(factor.ToString())) {
                return true;
            }
        }
        foreach (string str in array) {
            if (str != " " && int.Parse(str) % number == 0 && int.Parse(str) != number) {
                return true;
            }
        }
        return false;
    }
}