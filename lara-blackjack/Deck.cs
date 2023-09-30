namespace lara_blackjack;

public class Deck
{
    private List<Card> _cards = new List<Card>();
    public List<Card> cards
    {
        get { return _cards; }
    }

    public Deck()
    {
        foreach (Suit suits in Enum.GetValues(typeof(Suit)))
        {
            int values = 1;
            foreach (Rank ranks in Enum.GetValues(typeof(Rank)))
            {
                _cards.Add(new Card(ranks, suits, values));
                if (values < 10)
                {
                    values++;
                }
            }
        }
    }

    public void RemoveCard(int index)
    {
        _cards.RemoveAt(index);
    }
}