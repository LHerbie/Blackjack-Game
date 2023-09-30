namespace lara_blackjack;

public interface IPerson
{
    Hand hand { get; }
    bool blackjack { get; }
    bool bust { get; }
}