namespace lara_blackjack;

public class Player : IPerson
{
    public Hand hand { get { return _hand; } }
    private Hand _hand = new Hand();
    public bool bust { get { return _bust; } set { _bust = value; } }
    private bool _bust;
    public bool blackjack { get { return _blackjack; } set { _blackjack = value; } }
    private bool _blackjack;

    public void TakeCardFromDealer(Card card)
    {
        _hand.AddCard(card);
    }
}