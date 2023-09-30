using lara_blackjack;

namespace lara_blackjack_tests;

public class HandTests
{
    [Fact]
    public void NumberOfCardsInHandIncreasesWhenACardIsAdded()
    {
        // ARRANGE
        Hand hand = new Hand();

        // ACT
        hand.AddCard(new Card(Rank.Ace, Suit.Clubs, 1));

        // ASSERT
        Assert.Equal(1, hand.cards.Count);
    }
    
    [Fact]
    public void LastCardInHandIsEqualToLastCardAdded()
    {
        // ARRANGE
        Hand hand = new Hand();
        Card card1 = new Card(Rank.Eight, Suit.Diamonds, 8);
        Card card2 = new Card(Rank.Jack, Suit.Spades, 10);
        
        // ACT
        hand.AddCard(card1);
        hand.AddCard(card2);
        Card lastCard = hand.cards.Last();
        
        // ASSERT
        Assert.Equal(card2, lastCard);
    }
    
    [Theory]
    // ARRANGE
    [InlineData(Rank.Ace, 1, Rank.Ace, 1, 2)]
    [InlineData(Rank.Ten, 10, Rank.Seven, 7, 17)]
    [InlineData(Rank.Ace, 1, Rank.Four, 4,5)]
    public void CardsInHandCountedCorrectly(Rank rank1, int value1, Rank rank2, int value2, int expectedResult)
    {
        // ARRANGE
        Hand hand = new Hand();
        Card card1 = new Card(rank1, Suit.Diamonds, value1);
        Card card2 = new Card(rank2, Suit.Spades, value2);
        
        // ACT
        hand.AddCard(card1);
        hand.AddCard(card2);
        int actualResult = hand.CountHand();
        
        // ASSERT
        Assert.Equal(expectedResult, actualResult);
    }
    
    [Theory]
    // ARRANGE
    [InlineData(Rank.Ace, 1, Rank.Ten, 10, Rank.Ten, 10, 21)]
    [InlineData(Rank.Ace, 1, Rank.Seven, 7, Rank.Two, 2, 20)]
    [InlineData(Rank.Ace, 11, Rank.Ten, 10, Rank.Ace, 1, 12)]
    [InlineData(Rank.Nine, 9, Rank.Four, 4, Rank.Ace, 1, 14)]
    public void AceChanged(Rank rank1, int value1, Rank rank2, int value2, Rank rank3, int value3, int expectedResult)
    {
        // ARRANGE
        Hand hand = new Hand();
        Card card1 = new Card(rank1, Suit.Diamonds, value1);
        Card card2 = new Card(rank2, Suit.Spades, value2);
        Card card3 = new Card(rank3, Suit.Hearts, value3);
        
        // ACT
        hand.AddCard(card1);
        hand.AddCard(card2);
        hand.AddCard(card3);
        hand.AceController();
        int actualResult = hand.CountHand();
        
        // ASSERT
        Assert.Equal(expectedResult, actualResult);
    }
}