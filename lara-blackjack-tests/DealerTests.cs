using lara_blackjack;

namespace lara_blackjack_tests;

public class DealerTests
{
    
    [Fact]
    public void DeckContains52Cards()
    {
        // ARRANGE
        Dealer dealer = new Dealer();
        
        // ACT
        int deckSize = dealer.deck.cards.Count;
        
        // ASSERT
        Assert.Equal(52, deckSize);
    }
    
    [Theory]
    // ARRANGE
    [InlineData(3, 49)]
    [InlineData(1, 51)]
    [InlineData(40, 12)]
    public void DealersDeckDecreasesWhenACardIsDealtToSelf(int cardsToDeal, int expectedResult)
    {
        // ARRANGE
        Dealer dealer = new Dealer();

        // ACT
        for (int i = 0; i < cardsToDeal; i++)
        {
            dealer.DealToSelf();
        }

        int actualResult = dealer.deck.cards.Count();
        
        // ASSERT
        Assert.Equal(expectedResult, actualResult);
    }
    
    [Theory]
    // ARRANGE
    [InlineData(3, 49)]
    [InlineData(1, 51)]
    [InlineData(40, 12)]
    public void DealersDeckDecreasesWhenACardIsDealtToPlayer(int cardsToDeal, int expectedResult)
    {
        // ARRANGE
        Dealer dealer = new Dealer();
        Player player = new Player();

        // ACT
        for (int i = 0; i < cardsToDeal; i++)
        {
            dealer.DealToPlayer(player);
        }

        int actualResult = dealer.deck.cards.Count();
        
        // ASSERT
        Assert.Equal(expectedResult, actualResult);
    }
    
    [Theory]
    // ARRANGE
    [InlineData(3)]
    [InlineData(1)]
    [InlineData(40)]
    public void DealersHandIncreasesWhenACardIsDealt(int cardsToDeal)
    {
        // ARRANGE
        Dealer dealer = new Dealer();

        // ACT
        for (int i = 0; i < cardsToDeal; i++)
        {
            dealer.DealToSelf();
        }

        int actualResult = dealer.hand.cards.Count();
        
        // ASSERT
        Assert.Equal(cardsToDeal, actualResult);
    }
    
    [Theory]
    // ARRANGE
    [InlineData(3)]
    [InlineData(1)]
    [InlineData(40)]
    public void PlayersHandIncreasesWhenACardIsDealt(int cardsToDeal)
    {
        // ARRANGE
        Dealer dealer = new Dealer();
        Player player = new Player();

        // ACT
        for (int i = 0; i < cardsToDeal; i++)
        {
            dealer.DealToPlayer(player);
        }

        int actualResult = player.hand.cards.Count();
        
        // ASSERT
        Assert.Equal(cardsToDeal, actualResult);
    }
    
    [Fact]
    public void CardDealtIsNotPresentInDeckAnymore()
    {
        // ARRANGE
        Dealer dealer = new Dealer();
        
        // ACT
        dealer.DealToSelf();
        Card card = dealer.hand.cards[0];
        bool isPresentInDeck = false;
        Deck deck = dealer.deck;
        List<Card> deckCards = dealer.deck.cards;
        foreach (Card cards in deckCards)
        {
            if (cards == card)
            {
                isPresentInDeck = true;
            }
        }

        // ASSERT
        Assert.False(isPresentInDeck);

    }
    
}