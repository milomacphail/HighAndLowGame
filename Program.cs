using System;

namespace HighOrLow
{
    public class Card
    {
        public enum SuitValues { Clubs = 0, Diamonds = 1, Hearts = 2, Spades = 4 };
        Array suits = Enum.GetValues(typeof(SuitValues));
        SuitValues randomSuitValue = (SuitValues)(new Random()).Next(0, 3);

        public int CardValue;
        public string CardSuit;

        public Card()
        {
            Random randomCardValue = new Random();
            this.CardValue = randomCardValue.Next(2, 14);
            this.CardSuit = randomSuitValue.ToString();
        }

        public Card(int CardValue, int CardSuit)
        {
            this.CardValue = CardValue;
            this.CardSuit = randomSuitValue.ToString();
        }

        public Card(int CardValue)
        {
            this.CardValue = CardValue;
        }
    }

    public class Game
    {
        public void PlayGame()
        {

            var startingCard = new Card();
            var nextCard = new Card();


            int correctGuesses = 0;

            if (startingCard.CardValue == nextCard.CardValue && startingCard.CardSuit == nextCard.CardSuit)
            {
                nextCard = new Card();
            }
            else
            {
                Console.WriteLine("Drawn Card: {0} {1}", startingCard.CardValue, startingCard.CardSuit);
                Console.WriteLine("Guess higher or lower: ");
                string input = Console.ReadLine();
                if (input.ToLower() != "high" && input.ToLower() != "low")
                {
                    Console.WriteLine("Please guess high or low: ");
                }
                else if (nextCard.CardValue > startingCard.CardValue && input.ToLower() == "high" || nextCard.CardValue < startingCard.CardValue && input.ToLower() == "low")
                {
                    Console.WriteLine("Card Drawn: {0} {1}", nextCard.CardValue, nextCard.CardSuit);
                    Console.WriteLine("Nice guess! You win!");
                    correctGuesses++;
                    Console.WriteLine("Streak: {0}", correctGuesses);
                    nextCard = startingCard;
                    nextCard = new Card();
                    PlayGame();

                }
                else if (nextCard.CardValue < startingCard.CardValue && input.ToLower() == "high" || nextCard.CardValue > startingCard.CardValue && input.ToLower() == "low")
                {
                    Console.WriteLine("{0} {1}", nextCard.CardValue, nextCard.CardSuit);
                    Console.WriteLine("Ooooooh! Better luck next time! You lose.");
                    correctGuesses = 0;
                    Console.WriteLine("New game?);
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                var newGame = new Game();
                newGame.PlayGame();

            }
        }
    }
}

