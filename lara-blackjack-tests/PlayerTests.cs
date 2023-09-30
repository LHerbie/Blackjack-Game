using lara_blackjack;

namespace lara_blackjack_tests;

public class PlayerTests
{
    [Fact]
    public void NumberOfCardsInHandIncreasesWhenACardIsTakenFromDealer()
    {
        // ARRANGE
        Player player = new Player();

        // ACT
        player.TakeCardFromDealer(new Card(Rank.Ace, Suit.Clubs, 1));

        // ASSERT
        Assert.Equal(1, player.hand.cards.Count);
    }
    
    [Fact]
    public void LastCardInHandIsEqualToLastCardAdded()
    {
        // ARRANGE
        Player player = new Player();
        Card card1 = new Card(Rank.Eight, Suit.Diamonds, 8);
        Card card2 = new Card(Rank.Jack, Suit.Spades, 10);
        
        // ACT
        player.TakeCardFromDealer(card1);
        player.TakeCardFromDealer(card2);
        Card lastCard = player.hand.cards.Last();
        
        // ASSERT
        Assert.Equal(card2, lastCard);
    }
}