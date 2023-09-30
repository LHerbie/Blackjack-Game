// See https://aka.ms/new-console-template for more information

using lara_blackjack;

Dealer dealer = new Dealer();
Player player = new Player();
Game game = new Game(dealer, player);

game.PlayGame();