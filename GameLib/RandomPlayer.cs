using System;

public class RandomPlayer : Player
{
    public RandomPlayer(AvailableCards availableCards)
    {
        Random rnd = new Random();
        int cardNumb = rnd.Next(2, 5);

        for (int i = 0; i < cardNumb; i++)
        {
            this.Cards.Add(availableCards.GetRandomCard());
        }
    }
}