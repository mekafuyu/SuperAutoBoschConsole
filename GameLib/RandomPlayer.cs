using System;

public class RandomPlayer : Player
{
    public RandomPlayer(Game game)
    {
        Random rnd = new Random();
        int cardNumb = rnd.Next(2, 5);

        for (int i = 0; i < cardNumb; i++)
        {
            var card = game.AvailableCards.GetRandomCard();
            card.Player = this;
            this.Cards.Add(card);
        }
    }
}