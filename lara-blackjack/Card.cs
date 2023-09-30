namespace lara_blackjack;

public class Card
{
    private readonly Rank _rank;
    private readonly Suit _suit;
    private int _value;
    public int value { get { return _value; } }

    public Card(Rank rank, Suit suit, int value)
    {
        _rank = rank;
        _suit = suit;
        _value = value;
    }

    public void ChangeAceValue(bool changeValueTo11)
    {
        if (_rank == Rank.Ace)
        {
            if (changeValueTo11)
            {
                _value = 11;
            }
            else if (!changeValueTo11)
            {
                _value = 1;
            }
            else
            {
                throw new CaseDoesNotExistException("ERROR: Cannot change ace value. Input to change Ace is invalid.");
                // Mentor feedback: Learn about try-catch statements - could be more useful
            }
        }
    }

    public void DisplayCard()
    {
        Console.Write(" [" + _rank + " (" + _value + "), " + _suit + "] ");
    }
}

