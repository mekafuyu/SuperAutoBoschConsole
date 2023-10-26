using System.Collections.Generic;

public class Store
{
    public List<Card> Cards { get; set; } = new();
    public List<Card> FreezedCards { get; set; } = new();

    public int MaxCards = 3;

    public void SetOwner(Player player)
    {
        foreach (Card card in this.Cards)
        {
            card.Player = player;
        }
    }

    public void RefreshStore(AvailableCards availableCards)
    {
        this.Cards = new();
        foreach (Card card in FreezedCards)
            this.Cards.Add(card);

        int cardsToAdd = this.MaxCards - this.Cards.Count();

        for (int i = 0; i < cardsToAdd; i++)
        {
            this.Cards.Add(availableCards.GetRandomCard());
        }
    }

    public void FreezeItem(int item)
    {
        if(item > this.Cards.Count() - 1 || item < 0)
            return;

        if(this.FreezedCards.Contains(this.Cards[item]))
            this.FreezedCards.Remove(this.Cards[item]);
        
        this.FreezedCards.Add(this.Cards[item]);
    }

    public Card Buy(int selectedCard)
    {
        var card = this.Cards[selectedCard];
        this.Cards[selectedCard] = null;
        return card;
    }
}