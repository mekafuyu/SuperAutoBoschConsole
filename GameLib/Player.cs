using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
public class Player : ICloneable
{
    public int gold { get; set; } = 10;
    public int life { get; set; } = 5;
    public int trophies { get; set; } = 0;
    public List<Card> Cards { get; set; } = new();
    public Store Store { get; set; } = new();


    public void Buy(int item)
    {
        if(gold < 3 || this.Store.Cards[item] is null)
            return;
        if(this.Cards.Count() > 4)
            return;
            

        this.RemoveGold(3);
        this.Cards.Add(this.Store.Buy(item));
        this.Cards.Last().Player = this;
        this.Cards.Last().onBuy();
    }

    public void Sell(int selectedCard)
    {
        this.gold += this.Cards[selectedCard].Level;
        this.Cards[selectedCard].onSell();
        this.Cards[selectedCard] = null;
    }

    public List<Card> RefreshStore(Player player, AvailableCards availableCards, bool free)
    {
        if(this.gold < 1 && !free)
            return this.Store.Cards;
        if(!free)
            this.RemoveGold(1);
        this.Store.RefreshStore(availableCards);
        this.Store.SetOwner(player);
        return this.Store.Cards;
    }

    public void GiveGold(int gold)
        => this.gold += gold;
    public void RemoveGold(int gold)
        {
            if(this.gold <= 0)
                return;
            this.gold -= gold;
        }

    public object Clone()
    {
        var player = new Player();
        foreach (Card card in this.Cards)
        {
            Card newCard = card.Clone() as Card;
            newCard.Player = player;
            player.Cards.Add(newCard);
        }
        return player;
    }
}