namespace lara_blackjack;

public static class Messages
{
    private static readonly string playerWinMessage = "\nCongratulations! You won.";
    private static readonly string dealerWinMessage = "\nOh no! The dealer won.";
    private static readonly string tieMessage = "\nIt's a tie!";

    public static void PrintFinalScores(int player, int dealer)
    {
        Console.WriteLine("\nYour score is: " + player + "! \n" 
                          + "The dealer's score is: " + dealer + "!");
    }
    public static void Tie()
    {
        Console.WriteLine(tieMessage);
    }

    public static void Winner(bool isPlayerScoreLarger)
    {
        if (isPlayerScoreLarger)
        {
            Console.WriteLine(playerWinMessage);
        }
        else if (!isPlayerScoreLarger)
        {
            Console.WriteLine(dealerWinMessage);
        }
        else
        {
            throw new CaseDoesNotExistException("ERROR: Game is trying to declare a winner when there is not a winner.");
            // Mentor feedback: Learn about try-catch statements - could be more useful
        }
    }

    public static void Bust(string playerOrDealer)
    {
        string person = "";
        if (playerOrDealer == "Dealer")
        {
            person = "The dealer";
        }
        else if (playerOrDealer == "Player")
        {
            person = "You";
        }
        else
        {
            throw new CaseDoesNotExistException("ERROR: Bust() was called for someone other than the player or dealer.");
            // Mentor feedback: Learn about try-catch statements - could be more useful
        }
        
        Console.WriteLine("\nOh no! " + person + " went bust.");
    }

    public static void Blackjack(string playerOrDealer)
    {
        string person = "";
        if (playerOrDealer == "Dealer")
        {
            person = "The dealer";
        }
        else if (playerOrDealer == "Player")
        {
            person = "You";
        }
        else
        {
            throw new CaseDoesNotExistException("ERROR: Blackjack() was called for someone other than the player or dealer.");
            // Mentor feedback: Learn about try-catch statements - could be more useful
        }
        
        Console.WriteLine(person + " got Blackjack!");
    }

    public static void PrintWhoseTurnItIs(string playerOrDealer)
    {
        string person = "";
        if (playerOrDealer == "Dealer")
        {
            person = "It's the dealer's";
        }
        else if (playerOrDealer == "Player")
        {
            person = "It's your";
        }
        else
        {
            throw new CaseDoesNotExistException("ERROR: PrintWhoseTurnItIs() was called for someone other than the player or dealer.");
            // Mentor feedback: Learn about try-catch statements - could be more useful
        }
        Console.WriteLine("\n* * * * *\n" + playerOrDealer + " turn!\nPress Enter/return to continue.");
        Console.ReadLine();
    }
}