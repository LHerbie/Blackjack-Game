using lara_blackjack;

namespace lara_blackjack_tests;

public class CardTests
{
    [Theory]
    // ARRANGE
    [InlineData(true, Rank.Ace, Suit.Clubs, 1, 11)]
    [InlineData(false, Rank.Ace, Suit.Clubs, 1, 1)]
    [InlineData(true, Rank.Two, Suit.Hearts, 2, 2)]
    [InlineData(false, Rank.Queen, Suit.Spades, 10, 10)]
    [InlineData(false, Rank.Ace, Suit.Diamonds, 11, 1)]
    [InlineData(true, Rank.Ace, Suit.Diamonds, 11, 11)]
    public void ValueChangesOnlyWhenCardIsAce(bool is11, Rank rank, Suit suit, int value, int expectedValue)
    {
        // ARRANGE
        Card card = new Card(rank, suit, value);

        // ACT
        card.ChangeAceValue(is11);

        // ASSERT
        Assert.Equal(expectedValue, card.value);
    }
}