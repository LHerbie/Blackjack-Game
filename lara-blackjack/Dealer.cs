namespace lara_blackjack;

public class Dealer : IPerson
{
    public Deck deck { get { return _deck; } } // Mentor feedback: Could move deck into gae class -- dealer is a little overloaded
    private Deck _deck = new Deck();
    public Hand hand { get { return _hand; } }
    private Hand _hand = new Hand();
    public bool bust { get { return _bust; } set { _bust = value; } }
    private bool _bust;
    public bool blackjack { get { return _blackjack; } set { _blackjack = value; } }
    private bool _blackjack;

    public void DealToSelf()
    {
        Random random = new Random();
        int cardIndex = random.Next(_deck.cards.Count);
        _hand.AddCard(_deck.cards[cardIndex]);
        _deck.RemoveCard(cardIndex);
    }

    public void DealToPlayer(Player player)
    {
        Random random = new Random();
        int cardIndex = random.Next(_deck.cards.Count);
        player.TakeCardFromDealer(_deck.cards[cardIndex]);
        _deck.RemoveCard(cardIndex);
    }

    public string HitOrStay()
    {
        Console.WriteLine("\nWould you like to HIT or STAY? Please enter HIT or STAY.");
        string hitOrStay = Console.ReadLine();

        while ((hitOrStay != "STAY") && (hitOrStay != "HIT"))
        {
            Console.WriteLine("\nInvalid entry. Please enter HIT or STAY.");
            hitOrStay = Console.ReadLine();
        }

        if (hitOrStay == "HIT")
        {
            Console.WriteLine("\nYou have selected HIT. The dealer will give you another card.");
        }
        else if (hitOrStay == "STAY")
        {
            Console.WriteLine(
                "\nYou have selected STAY. Your turn is now over.");
        }
        else
        {
            throw new CaseDoesNotExistException("ERROR: Game cannot proceed. - player can only hit or stay.");
            // Mentor feedback: Learn about try-catch statements - could be more useful
        }
        
        return hitOrStay;
    }
}