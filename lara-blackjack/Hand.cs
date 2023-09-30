namespace lara_blackjack;

public class Hand
{
    private List<Card> _cards = new List<Card>();
    public List<Card> cards { get { return _cards; } }
    
    public void AddCard(Card card)
    {
        _cards.Add(card);
    }

    public int CountHand()
    {
        int total = 0;
        foreach (Card card in _cards)
        {
            total += card.value;
        }

        return total;
    }

    public void DisplayHand(string person)
    {
        Console.Write(person + " currently at " + CountHand());
        Console.Write("\nWith hand: [");
        int i = 0;
        foreach (Card card in _cards)
        {
            card.DisplayCard();
            i++;
        }
        Console.Write("]\n");
    }

    public void AceController()
    {
        if (CountHand() < 11)
        {
            foreach (Card card in _cards)
            {
                card.ChangeAceValue(true);
            }
        }
        else if (CountHand() > 11)
        {
            foreach (Card card in _cards)
            {
                card.ChangeAceValue(false);
            }
        }
        else
        {
            throw new CaseDoesNotExistException("ERROR: Total count of hand is an invalid number.");
            // Mentor feedback: Learn about try-catch statements - could be more useful
        }
    }
}