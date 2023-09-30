using System.Net.Http.Json;

namespace lara_blackjack;

public class Game
{
    private string _whoseTurn = "";
    private Dealer _dealer;
    private Player _player;
    private bool _gameOver;
    
    public Game(Dealer dealer, Player player)
    {
        _dealer = dealer;
        _player = player;
    }

    public void PlayersTurn()
    {
        _whoseTurn = "Player";
        Messages.PrintWhoseTurnItIs(_whoseTurn);
        string hitOrStay = _dealer.HitOrStay();
        
        while ((!_gameOver) && (hitOrStay == "HIT"))
        {
            _dealer.DealToPlayer(_player);
            _player.hand.AceController();
            _player.hand.DisplayHand(_whoseTurn);

            if (_player.hand.CountHand() > 21)
            {
                Messages.Bust(_whoseTurn);
                _player.bust = true;
                _gameOver = true;
                return;
            }
            else if (_player.hand.CountHand() == 21)
            {
                Messages.Blackjack(_whoseTurn);
                _player.blackjack = true;
                _gameOver = true;
                return;
            }
            
            hitOrStay = _dealer.HitOrStay();
        }
    }

    public void DealersTurn()
    {
        _whoseTurn = "Dealer";
        Messages.PrintWhoseTurnItIs(_whoseTurn);
        while (_dealer.hand.CountHand() < 17)
        {
            _dealer.DealToSelf();
            _dealer.hand.AceController();
            if (_dealer.hand.CountHand() > 21)
            {
                _dealer.hand.DisplayHand(_whoseTurn);
                Messages.Bust(_whoseTurn);
                _dealer.bust = true;
                _gameOver = true;
                return;
            }
            else if (_dealer.hand.CountHand() == 21)
            {
                _dealer.hand.DisplayHand(_whoseTurn);
                Messages.Blackjack(_whoseTurn);
                _dealer.blackjack = true;
                _gameOver = true;
                return;
            }
        }
        _dealer.hand.DisplayHand(_whoseTurn);
    }

    public void PlayGame()
    {
        for (int i = 0; i < 2; i++)
        {
            _dealer.DealToPlayer(_player);
            _dealer.DealToSelf();
            _player.hand.AceController();
            _dealer.hand.AceController();
        }
        _player.hand.DisplayHand(_whoseTurn);
        
        PlayersTurn();
        DealersTurn();

        if (!_gameOver)
        {
            Messages.PrintFinalScores(_player.hand.CountHand(), _dealer.hand.CountHand());
            if (_player.hand.CountHand() == _dealer.hand.CountHand())
            {
                Messages.Tie();
            }
            else
            {
                Messages.Winner((_player.hand.CountHand() > _dealer.hand.CountHand()));
            }
        }
        else if (_gameOver)
        {
            if (((_dealer.bust == true) && (_player.bust == true)) || ((_dealer.blackjack == true) && (_player.blackjack == true)))
            {
                Messages.Tie();
            }
            else if ((_dealer.blackjack == true)||(_player.bust == true))
            {
                Messages.Winner(false);
            }
            else if ((_dealer.bust == true)||(_player.blackjack == true))
            {
                Messages.Winner(true);
            }
            else
            {
                throw new CaseDoesNotExistException("ERROR: Game has entered gameover state under impossible conditions.");
                // Mentor feedback: Learn about try-catch statements - could be more useful
            }
        }
        else
        {
            throw new CaseDoesNotExistException("ERROR: Game is in a state where it is both over and not over at the same time");
            // Mentor feedback: Learn about try-catch statements - could be more useful
        }
    }
}