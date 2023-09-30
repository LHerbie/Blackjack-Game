using lara_blackjack;

namespace lara_blackjack_tests;

public class DeckTests
{
    [Fact]
    public void NumberOfCardsInADeckIs52()
    {
        // ARRANGE
        Deck deck = new Deck();

        // ACT
        int nCards = deck.cards.Count;

        // ASSERT
        Assert.Equal(52, nCards);
    }
    
    [Fact]
    public void NoDuplicateCardsInDeck()
    {
        // ARRANGE
        Deck deck = new Deck();
        
        // ACT
        int uniqueCards = 0;
        foreach (Card card in deck.cards)
        {
            foreach (Card card2 in deck.cards)
            {
                if (card == card2)
                {
                    uniqueCards++;
                }
            }
        }
        
        // ASSERT
        Assert.Equal(52, uniqueCards);
    }
    
    [Theory]
    // ARRANGE
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(15)]
    [InlineData(50)]
    public void RemoveCardRemovesCorrectCard(int index)
    {
        // ARRANGE
        Deck deck = new Deck();
        Card card = deck.cards[index];
        
        // ACT
        deck.RemoveCard(index);
        bool containsCard = deck.cards.Contains(card);
        
        // ASSERT
        Assert.False(containsCard);
    }
}