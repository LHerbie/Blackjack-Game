# Blackjack Overview

This is a text-based Blackjack engine, where you can play against a dealer following standard house rules.

This game is simplified in comparison to commercial Blackjack:

* It's entirely text-based.
* You play as a single player against the dealer.
* There's no gambling system involved.

## Rules
The rules of for playing are as follows:

* Both the player and the dealer receive two cards from a shuffled deck. We use a single deck, while casinos often use a "shoe" with six decks.
* After receiving the first two cards, you can choose to "hit" (get another card) or "stay" (keep your current cards). You can stop hitting at any point.
* Number cards (2 through 10) have values equal to their face value, face cards are worth 10, and an Ace can be worth either 1 or 11. For example, if you have a Jack and an Ace, you'd count the Ace as 11 to reach 21 (resulting in a blackjack). But if your hand is worth 18, and you get an Ace, you'd count it as 1 to avoid busting (going over 21).
* After your turn, the dealer tries to do the same. The dealer must keep hitting until their total reaches at least 17 without busting.

## Scoring
Scoring in the game follows these simple rules:

* If you have a blackjack, you win unless the dealer also has a blackjack, resulting in a tie.
* If the dealer busts and you don't, you win.
* If you bust, the dealer wins.
* If neither you nor the dealer busts, the one closest to 21 wins.

___
## Getting Started

1. Make sure you have the [.NET Core runtime](https://dotnet.microsoft.com/download/dotnet-core) installed on your system.

2. Clone this repository to your local machine: 
```
git clone https://github.com/LHerbie/Blackjack-Game.git
```

3. Navigate to the project directory: 
```
cd Blackjack-Game
```
4. Compile and run the program:
```
dotnet run
```
___
# Table of Contents

* [Classes](#classes)
  * [Card Class](#card)
  * [Deck Class](#deck)
  * [Hand Class](#hand)
  * [Player Class](#player)
  * [Dealer Class](#dealer)
  * [BustOrBlackjack Class](#bustorblackjack)
  * [Game Class](#game)
* [Immutable Classes / Objects](#immutable-objects)
  * [Messages Class](#messages)
* [Interfaces](#interfaces)
  * [IPerson Interface](#iperson)
* [Exceptions](#exceptions)
  * [CaseDoesNotExist Exception](#casedoesnotexistexception)
* [Enums](#enums)
  * [Rank Enum](#rank)
  * [Suit Enum](#suit)


---

# Classes

## Card

Represents a card in the game with a rank, suit, and numerical value, defined by `_rank`, `_suit`, and `_value` respectively.

The `ChangeAceValue` method changes the `_value` field of an Ace card. It sets `_value` to 11 if `is11` is true, or 1 if false.

The `DisplayCard` method prints the card to the user in this format: ` [_rank (_value), _suit]`.

## Deck

Represents a deck of cards (a list of cards, `_cards`) used in the game.

Upon construction, 52 cards are created to make up `_cards`, one for each combination of `_rank` and `_suit`.

The `RemoveCard` method removes the card at the specified `index` in `_cards`.

## Hand

Represents a player's current hand of cards.

The `_cards` field is a list of cards in the hand.

The `AddCard` method adds a card to the hand.

The `CountHand` method calculates the total value of the cards in the hand.

## Player

Represents the player interacting with the console.

The `_hand`, `_bust`, and `blackjack` are part of the [IPerson Interface](#iperson).

The `TakeCardFromDealer` method lets the player take a card dealt by the dealer and add it to their `_hand`.

## Dealer

Represents the dealer the player is playing against.

The `_deck` field represents the remaining cards in the deck. The dealer deals cards from this deck.

The `_hand`, `_bust`, and `blackjack` are part of the [IPerson Interface](#iperson).

The `DealToSelf` method allows the dealer to give themselves a card, which is added to their `_hand`.

The `DealToPlayer` method lets the dealer give a card to the player from the `_deck`.

The `HitOrStay` method allows the dealer to ask the player whether they want another card (hit) or want to end their turn (stay).

## Game

This class controls the game's structure and steps.

`_whoseTurn` represents whether it is currently the `"Player"` or `"Dealer"` turn.

`_dealer` is the dealer for the game.

`_player` is the player for the game.

`_gameOver` is true when someone has gone bust or achieved a blackjack.

# Immutable Objects

## Messages

This static class is an immutable object storing messages printed to the player at the end of the game.

`playerWinMessage` is the message displayed when the player wins, printed using the `Winner` method.

`dealerWinMessage` is the message shown when the dealer wins, printed using the `Winner` method.

`tieMessage` is the message displayed when there is a tie.

The `PrintFinalScores` method prints both the player's and dealer's final scores after the round.

The `PrintWhoseTurnItIs` informs the player whose turn is starting.

The `Blackjack` method notifies the player when either the player or the dealer gets a blackjack.

The `Bust` method informs the player when either the player or the dealer goes bust.

# Interfaces

## IPerson

An interface for any person involved in the game.

Any person in the game should have a `hand` of cards specific to them.

A person can either go bust or achieve a blackjack. `bust` is true when a person goes bust and false otherwise. `blackjack` is true when a person achieves a blackjack and false otherwise.

# Exceptions

## CaseDoesNotExistException

This exception is used for sections of code that should never be reached, such as when an `if` statement covers all cases, and the `else` should never be entered, causing this exception to be thrown.

# Enums

## Rank

Represents a card's rank, which can be Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King.

## Suit

Represents a card's suit. A card can be Clubs, Diamonds, Hearts, Spades.